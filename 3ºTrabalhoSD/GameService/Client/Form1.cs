using System;
using System.ServiceModel;
using System.Threading;
using System.Windows.Forms;
using Client.ServiceReference;
using Service.Service;
using IServiceClient = Client.ServiceReference.IServiceClient;

namespace Client
{
    public partial class Form1 : Form, IForm
    {
        private readonly SynchronizationContext _syncCtx;
        private MyClass _mc;

        public Form1()
        {
            InitializeComponent();
            _mc = new MyClass(this);
            _syncCtx = SynchronizationContext.Current;
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
            try
            {
                int x = int.Parse(xInput.Text);
                int y = int.Parse(yInput.Text);
                _mc.Play(x, y);
            }
            catch (FormatException)
            {
                outputPanel.AppendText("X or Y with invalid input\n");
            }
        }

        public void SetNotification(string s)
        {
            _syncCtx.Post(state => outputPanel.AppendText(s + "\n"), null);
        }

        public void SetPublicity(string s)
        {
            _syncCtx.Post(state => publicityPanel.AppendText(s + "\n"), null);
        }

        public void SetPlayerStatus(string s)
        {
            _syncCtx.Post(state => playerStatusOutput.Text = s + "\n", null);
        }

        private void unregisterBtn_Click(object sender, EventArgs e)
        {
            _mc.Unregister();
        }
    }

    public interface IForm
    {
        void SetNotification(string s);
        void SetPublicity(string s);
        void SetPlayerStatus(string s);
    }

    [CallbackBehavior(UseSynchronizationContext = false)]
    public class MyClass : INotification, IServiceClientCallback
    {
        private IServiceClient _serv;
        private readonly IForm _f;
        public MyClass(IForm f)
        {
            _f = f;
        }

        public void RegisterPlayer(string playerId)
        {
            _serv = new ServiceClientClient(new InstanceContext(this));
            try
            {
                _serv.RegisterPlayer(playerId);
            }
            catch (FaultException<RegisterException> exception)
            {
                SetPublicity(exception.Message + "\n");
            }
        }

        public void SetPublicity(string p)
        {
            _f.SetPublicity(p);
        }

        public void SetNotification(string p)
        {
            _f.SetNotification(p);
        }

        public void SetPlayerData(string p)
        {
            _f.SetPlayerStatus(p);
        }

        public void Play(int x, int y)
        {
            _serv.Play(x, y);
        }

        public void Unregister()
        {
            _serv.RemovePlayer();
        }
    }
}
