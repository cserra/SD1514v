using System;
using System.ServiceModel;
using System.Windows.Forms;
using Client.ServiceReference;
using Service.Service;
using IServiceClient = Client.ServiceReference.IServiceClient;

namespace Client
{
    public partial class Form1 : Form, IForm
    {
        private MyClass _mc;

        public Form1()
        {
            InitializeComponent();
            _mc = new MyClass(this);
        }

        private void registerBtn_Click(object sender, EventArgs e)
        {
            string _playerId = userNameInput.Text;
            if (_playerId.Length == 0)
            { 
                outputPanel.AppendText("Empty test\n");
                return;
            }
            _mc.RegisterPlayer(userNameInput.Text);
            outputPanel.ReadOnly = true;
        }

        private void PlayBtn_Click(object sender, EventArgs e)
        {
            /*try
            {
                int x = int.Parse(xInput.Text);
                int y = int.Parse(yInput.Text);
                _serv.Play(x, y);
                //outputPanel.AppendText(msg + "\n");
            }
            catch (FormatException)
            {
                outputPanel.AppendText("X or Y with invalid input\n");
            }*/
        }

        public void SetNotification(string s)
        {
            publicityPanel.AppendText(s + "\n");
        }

    }

    public interface IForm
    {
        void SetNotification(string s);
    }

    [CallbackBehavior(UseSynchronizationContext = false)]
    public class MyClass : INotification, IServiceClientCallback
    {
        private string _playerId;
        private IServiceClient _serv;
        private IForm _f;
        public MyClass(IForm f)
        {
            _f = f;
        }

        public void RegisterPlayer(string playerId)
        {
            _serv = new ServiceClientClient(new InstanceContext(this));
            try
            {
                _serv.RegisterPlayer(_playerId);
            }
            catch (FaultException<RegisterException> exception)
            {
                SetPublicity(exception.Message + "\n");
            }
        }

        public void SetPublicity(string p)
        {
            _f.SetNotification(p);
        }

        public void SetNotification(string p)
        {
            //outputPanel.AppendText(p + "\n");
        }

        public void SetPlayerData(string p)
        {
            throw new NotImplementedException();
        }
    }
}
