using System;
using System.Windows.Forms;

namespace Manager
{
    public partial class Form1 : Form
    {
        private bool isCreated = false;
        private ServiceReference.IServiceManager serv;

        public Form1()
        {
            InitializeComponent();
        }

        private void createBtn_Click(object sender, EventArgs e)
        {
            if (isCreated)
            {
                outputPanel.AppendText("Serviço já criado\n");
                return;
            }
            try
            {
                int size = int.Parse(sizeInput.Text);
                servicoLabel.Text = "Serviço criado";
                if (size < 0)
                {
                    outputPanel.AppendText("Tamanho incorreto\n");
                    return;
                }
                serv = new ServiceReference.ServiceManagerClient();
                serv.CreateBoard(size);
                sizeInput.ReadOnly = true;
                isCreated = true;
            }
            catch (Exception)
            {
                outputPanel.AppendText("Input invalido\n");
            }
        }
    }
}
