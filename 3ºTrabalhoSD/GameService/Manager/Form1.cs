using System;
using System.Windows.Forms;

namespace Manager
{
    public partial class Form1 : Form
    {
        private bool isSuspended = false;
        private bool _isCreated = false;
        private ServiceReference.IServiceManager _serv;

        public Form1()
        {
            InitializeComponent();
        }

        private void createBtn_Click(object sender, EventArgs e)
        {
            if (_isCreated)
            {
                outputPanel.AppendText("Serviço já criado\n");
                return;
            }
            try
            {
                int size = int.Parse(sizeInput.Text);
                if (size < 0)
                {
                    outputPanel.AppendText("Tamanho incorreto\n");
                    return;
                }
                _serv = new ServiceReference.ServiceManagerClient();
                _serv.CreateBoard(size);
                sizeInput.ReadOnly = true;
                _isCreated = true;
                servicoLabel.Text = "Serviço criado";
            }
            catch (Exception)
            {
                outputPanel.AppendText("Input invalido\n");
            }
        }

        private void newGameBtn_Click(object sender, EventArgs e)
        {
            try
            {
                int size = int.Parse(sizeInput.Text);
                if (size < 0)
                {
                    outputPanel.AppendText("Tamanho incorreto\n");
                    return;
                }
                _serv = new ServiceReference.ServiceManagerClient();
                _serv.CreateBoard(size);
                sizeInput.ReadOnly = true;
                _isCreated = true;
            }
            catch (Exception)
            {
                outputPanel.AppendText("Input invalido\n");
            }
        }

        private void publishBtn_Click(object sender, EventArgs e)
        {
            string p = publiInput.Text;
            if (p.Length > 0)
            {
                _serv.SendData(p);
            }
        }

        private void suspendBtn_Click(object sender, EventArgs e)
        {
            isSuspended = !isSuspended;
            if (isSuspended)
                suspendBtn.Text = "Resume Game";
            else
                suspendBtn.Text = "Stop Game";
            _serv.SuspendGame(isSuspended);
        }

        private void endGameBtn_Click(object sender, EventArgs e)
        {
            _serv.EndGame();
        }
    }
}
