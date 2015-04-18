using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Interface;

namespace Worker
{
        public class WorkerImpl : MarshalByRefObject, IWorker
        {
            private int _jobCount = 0;
            private double _jobSumTime = 0;
            private int _jobTotalCount = 0;
            private int _id;
            private int _maxJobs;
            private int _jobTimeout;

            public void Initialize(int id, int maxJobs, int jobTimeout)
            {
                _id = id;
                _maxJobs = maxJobs;
                _jobTimeout = jobTimeout;
            }

            public void SubmitJob(IJobCompletion jb, int jobId, string input, string output, string pathExe)
            {
                //need lock
                _jobCount++;
                _jobTotalCount++;
                new Thread(() =>
                {
                    try
                    {
                        ProcessStartInfo processInfo = new ProcessStartInfo(pathExe);
                        processInfo.CreateNoWindow = true;
                        processInfo.UseShellExecute = false;
                        processInfo.RedirectStandardInput = true;
                        processInfo.RedirectStandardOutput = true;
                        processInfo.Arguments = "\"" + input + "\"" + " " + "\"" + output + "\"";
                        Process newProc = Process.Start(processInfo);
                        // redireccionamento do Standard Input (teclado) e do standard output (ecrã)
                        StreamReader fin = new StreamReader(input);
                        StreamWriter fout =
                            new StreamWriter(output.Insert(output.IndexOf('.'), "EXEOUTPUT"));
                        StreamWriter swr = newProc.StandardInput;
                        streamCopy(fin, swr);
                        fin.Close();
                        swr.Close();
                        StreamReader srd = newProc.StandardOutput;
                        streamCopy(srd, fout);
                        if (newProc.WaitForExit(_jobTimeout * 1000) && newProc.ExitCode == 0)
                            jb.Terminated(jobId);
                        else jb.Error(jobId, "Job timeout");
                        fout.Close();
                        srd.Close();
                        //need lock
                        _jobSumTime += (newProc.ExitTime.Ticks / TimeSpan.TicksPerMillisecond)
                                       - (newProc.StartTime.Ticks / TimeSpan.TicksPerMillisecond);
                        //need lock jobcount--
                        _jobCount--;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                }).Start();
            }

            private static void streamCopy(StreamReader input, StreamWriter output)
            {
                char[] buffer = new char[32768];
                int read;

                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    output.Write(buffer, 0, read);
                }
            }

            public int GetJobCount()
            {
                return _jobCount;
            }

            public int GetId()
            {
                return _id;
            }

            public int GetMaxJobs()
            {
                return _maxJobs;
            }

            public double GetAverageTime()
            {
                return _jobSumTime / _jobTotalCount;
            }
    }
}
