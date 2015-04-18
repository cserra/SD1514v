using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Interface;

namespace Client.Admin.WinForms
{
    public partial class Form1 : Form
    {
        const string Configfile = "Client.Admin.WinForms.exe.config";
        private IBroker _broker;
        private List<int> _workerIds = new List<int>();

        public Form1()
        {
            InitializeComponent();
            
            RemotingConfiguration.Configure(Configfile, false);
            WellKnownClientTypeEntry[] entries = RemotingConfiguration.GetRegisteredWellKnownClientTypes();
            _broker = (IBroker)Activator.GetObject(entries[0].ObjectType, entries[0].ObjectUrl);
        }

        private void launchWorkerBtn_Click(object sender, EventArgs e)
        {
            int maxJobs = int.Parse(maxJobsTextBox.Text);
   
            int newId = _broker.LaunchWorker(maxJobs);
            _workerIds.Add(newId);
            workerIdsListBox.DataSource = null;
            workerIdsListBox.DataSource = _workerIds;
        }

        private void terminateWorkerBtn_Click(object sender, EventArgs e)
        {
            int idx = workerIdsListBox.SelectedIndex;
            if (idx < 0) return; //no items
            int idToRemove = _workerIds[idx];
            _workerIds.RemoveAt(idx);
            _broker.RemoveWorker(idToRemove);
            workerIdsListBox.DataSource = null;
            workerIdsListBox.DataSource = _workerIds;
        }
    }
}
