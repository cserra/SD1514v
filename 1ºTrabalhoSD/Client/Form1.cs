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

namespace Client
{
    public partial class Form1 : Form
    {
        private IBroker _broker;
        List<JobCompletion> _jobCompletions = new List<JobCompletion>();

        public Form1()
        {
            InitializeComponent();
            string configfile = "Client.exe.config";
            RemotingConfiguration.Configure(configfile, false);
            WellKnownClientTypeEntry[] entries = RemotingConfiguration.GetRegisteredWellKnownClientTypes();
            _broker = (IBroker)Activator.GetObject(entries[0].ObjectType, entries[0].ObjectUrl);
        }

        private void execFileBtn_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.ShowDialog();
            execFileTextbox.Text = dialog.FileName;
        }

        private void inputFileBtn_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.ShowDialog();
            inputFileTextBox.Text = dialog.FileName;
        }

        private void outputFileBtn_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.ShowDialog();
            outputFileTextBox.Text = dialog.FileName;
        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            JobCompletion jc = new JobCompletion();
            _jobCompletions.Add(jc);
            int id = _broker.SubmitJob(jc, inputFileTextBox.Text, outputFileTextBox.Text, execFileTextbox.Text);
            jobsListView.Items.Add(new ListViewItem(
                new[] {id.ToString(), jc.JobStatus.ToString()}));

        }

        private void refreshBtn_Click(object sender, EventArgs e)
        {
            if (jobsListView.SelectedItems.Count == 0) return;
            var idx = jobsListView.SelectedItems[0].Index;
            //if (idx == 0) return;
            var state = _jobCompletions[idx].JobStatus.ToString();
            jobsListView.Items[idx].SubItems[1].Text = state;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
