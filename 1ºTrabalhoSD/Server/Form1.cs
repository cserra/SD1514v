using System;
using System.Collections.Generic;
using System.Configuration;
using System.Deployment.Application;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;
using System.Runtime.Remoting.Channels.Ipc;
using System.Threading;
using System.Windows.Forms;
using Interface;

namespace Server
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            RemotingConfiguration.Configure("Server.exe.config", false);

        }

        private void totalWorkers_TextChanged(object sender, EventArgs e)
        {
            
        }

        public void UpdateValues(List<IWorker>workers)
        {
            //totalWorkers.SelectedText = "total Workers = "+ workers.Count;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }

    public class Constants
    {
        internal const string ACCESS_TYPE_NAME = "ADMIN";
        internal const string MAX_JOBS_NAME = "MAX_JOBS_AUTO";
        internal const string TIME_OUT_AUTO_NAME = "TIME_OUT_AUTO";
        internal const string TIME_OUT_MANUAL_NAME = "TIME_OUT_MANUAL";
        internal const string WORKER_EXE_NAME = WORKER_EXE_PATH +"/Worker.exe";
        internal const string WORKER_EXE_PATH = "../../../Worker/bin/Debug";
        
    }

    public class Broker : MarshalByRefObject, IBroker
    {
        private int _idsJobGen = 0;
        private int _idsWorkerGen = 2000;
        private object _lock = new object();
        private bool _AUTOnMANUAL;
        private readonly int MAX_JOBS;
        private readonly int JOB_TIME_OUT; // in secs
        private List<IWorker> _workers = new List<IWorker>(); 

        public Broker()
        {
            var appSettings = ConfigurationManager.AppSettings;
            String auto = appSettings[Constants.ACCESS_TYPE_NAME];
            _AUTOnMANUAL = auto.Equals("Auto");
            if (_AUTOnMANUAL)
            {
                JOB_TIME_OUT = Convert.ToInt32(appSettings[Constants.TIME_OUT_AUTO_NAME]);
                MAX_JOBS = Convert.ToInt32(appSettings[Constants.MAX_JOBS_NAME]);
            }
            else
            {
                JOB_TIME_OUT = Convert.ToInt32(appSettings[Constants.TIME_OUT_MANUAL_NAME]);
            }
        }

        public int SubmitJob(IJobCompletion jb, string input, string output, string pathExe)
        {
            lock (_lock)
            {

                int jobId = GenJobId();
                WorkerManager(jb, jobId, input, output, pathExe);
                return jobId;
            }
        }

        private void WorkerManager(IJobCompletion jb,int jobId, string input, string output, string pathExe)
        {
            if(_AUTOnMANUAL)
                _workers = CleanEmptyWorkers();
            IWorker worker = ChooseWorker();
            if (worker != null)
                worker.SubmitJob(jb, jobId,input,output,pathExe);
            else jb.Error(jobId, "No workers available");
        }

        private List<IWorker> CleanEmptyWorkers()
        {
            return _workers.Where(worker => worker.GetJobCount() != 0).ToList();
        }

        private IWorker ChooseWorker()
        {
            // ver se eh AUTO ou MANUAL
            // ver se precisa de ciar worker
            IWorker selected = null;
            foreach (IWorker worker in _workers)
            {
                //sujeito a outras regras de selecçao de workers
                if (worker.GetJobCount() != worker.GetMaxJobs())
                {
                    if ((selected == null) || ((worker.GetJobCount() <= selected.GetJobCount()) && (worker.GetAverageTime() <= selected.GetAverageTime())))
                        selected = worker;
                }
            }
            if (selected == null)
                if(_AUTOnMANUAL)
                    selected = CreateNewWorker(MAX_JOBS);
            return selected;
        }

        private IWorker CreateNewWorker(int maxJobs)
        {
            int id = GenWorkerId();
            ProcessStartInfo processInfo = new ProcessStartInfo();//Constants.WORKER_EXE_NAME);
            processInfo.FileName = Constants.WORKER_EXE_NAME;
            processInfo.CreateNoWindow = false;
            processInfo.UseShellExecute = false;
            processInfo.Arguments = id+"";
            processInfo.WorkingDirectory = Constants.WORKER_EXE_PATH;
            Process p = Process.Start(processInfo);
            
            string value = @"http://localhost:"+id+"/Worker.soap";
            
            IWorker w = (IWorker)Activator.GetObject(typeof(IWorker), value);
            //string file = "Server.exe.config";
            //RemotingConfiguration.Configure(file, false);
            w.Initialize(id, maxJobs, JOB_TIME_OUT);
            _workers.Add(w);
            return w;
        }

        private int GenWorkerId()
        {
            return _idsWorkerGen++;
        }

        private int GenJobId()
        {
            return _idsJobGen++;
        }

        public int LaunchWorker(int maxJobs)
        {
            if (!_AUTOnMANUAL)
            {
                IWorker w = CreateNewWorker(maxJobs);
                return w.GetId();
            }
            return -1;
        }

        public bool RemoveWorker(int id)
        {
            return _workers.Remove(_workers.Find(x => x.GetId() == id));
        }
    }
}