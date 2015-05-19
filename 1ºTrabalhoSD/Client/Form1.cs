using System;
using System.Threading;
using System.Windows.Forms;

namespace Client
{
    public partial class Form1 : Form
    {
        private Peer _peer;
        private readonly SynchronizationContext _syncCtx;

        public Form1()
        {
            InitializeComponent();
            _syncCtx = SynchronizationContext.Current;
        }

        private void CreatePeerBtn_Click(object sender, EventArgs e)
        {
            if (xmlFileTextBox.Text.Equals(""))
            {
                outputTextBox.Text = "You have to choose path!! Peer not created";
                return;
            }
          
            try
            {
                //Load config file
                PeerConfig pc = ConfigFileManager.Load(xmlFileTextBox.Text);
                //Activate a remoting peer
                _peer = PeerActivator.NewPeer(pc.Port, pc.PeerUri);
                //Bind peer from config file to remoting peer
                ConfigFileManager.BindPeerConfigToPeer(this, pc, _peer);
            }
            catch (Exception ex)
            {
                outputTextBox.Text = "Error creating peer. Error Message: "+ex.Message;
                outputTextBox.AppendText("Peer not created");
                return;
            }

            //change the form options for using after creating a peer
            xmlFileTextBox.ReadOnly = true;
            addPeerTextBox.ReadOnly = false;
            musicToSearchTextBox.ReadOnly = false;
            albumToSearchTextBox.ReadOnly = false;
            outputTextBox.Text = "Peer created. Uri: "+_peer.GetPeerURI();
        }

        private void addPeerBtn_Click(object sender, EventArgs e)
        {
            if (!CheckIfPeerIsCreated()) return;
            string peerToAdd = addPeerTextBox.Text;

            try
            {
                if (peerToAdd.Length != 0)
                    _peer.AddAssociatedPeer(peerToAdd);
                else
                    outputTextBox.Text = "You have to specify a URI!! Associated Peer not added";
            }catch (Exception ex)
            {
                outputTextBox.Text = "Invalid peer params. Not added!!! " + ex.Message;
            }
        }

        private void searchMusicBtn_Click(object sender, EventArgs e)
        {
            if (!CheckIfPeerIsCreated()) return;
            string music = musicToSearchTextBox.Text;
            _peer.SearchMusic(_peer, music, Peer.Ttl);
        }
        private void albumSearchMusicBtn_Click(object sender, EventArgs e)
        {
            if (!CheckIfPeerIsCreated()) return;
            string album = albumToSearchTextBox.Text;
            _peer.SearchAlbum(_peer, album, Peer.Ttl);
        }

        private Boolean CheckIfPeerIsCreated()
        {
            if (_peer == null)
            {
                outputTextBox.Text = "You have to create a Peer first!";
                return false;
            }
            return true;
        }

        public void SetOutputMessage(string self)
        {
            _syncCtx.Post(state => outputTextBox.AppendText(self + "\n"), null);
        }

        public void SetShowPeersTextBox(string self)
        {
            _syncCtx.Post(state => showPeersTextBox.AppendText(self + "\n"), null);
        }

        private void pathBtn_Click(object sender, EventArgs e)
        {
            if (xmlFileTextBox.Text != null)
            {
                var FD = new System.Windows.Forms.OpenFileDialog();
                if (FD.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string fileToOpen = FD.FileName;
                    xmlFileTextBox.Text = fileToOpen;
                   // System.IO.FileInfo File = new System.IO.FileInfo(FD.FileName);

                    //OR

                    System.IO.StreamReader reader = new System.IO.StreamReader(fileToOpen);
                    //etc
                }





                /*var folderBrowserDialog1 = new FolderBrowserDialog();
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    xmlFileTextBox.Text = folderBrowserDialog1.SelectedPath;
                }*/
            }
        }

    }
}