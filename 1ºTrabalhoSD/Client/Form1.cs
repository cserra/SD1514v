using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;
using System.Runtime.Remoting.Channels.Tcp;
using System.Threading;
using System.Windows.Forms;

namespace Client
{
    public partial class Form1 : Form
    {
        private static int pos = 0;
        private Peer _peer;
        private SynchronizationContext syncCtx;

        public Form1()
        {
            InitializeComponent();
            this.syncCtx = SynchronizationContext.Current;
        }

        private void CreatePeerBtn_Click(object sender, EventArgs e)
        {
            if (xmlFileTextBox.Text.Equals(""))
            {
                outputTextBox.AppendText("Must choose path!!");
                return;
            }
            xmlFileTextBox.ReadOnly = true;
            addPeerTextBox.ReadOnly = false;
            musicToSearchTextBox.ReadOnly = false;

            ConfigFileManager cfm = new ConfigFileManager();
            PeerConfig pc = cfm.Load(xmlFileTextBox.Text);

            SoapServerFormatterSinkProvider serverProv = new SoapServerFormatterSinkProvider();
            serverProv.TypeFilterLevel = System.Runtime.Serialization.Formatters.TypeFilterLevel.Full;
            SoapClientFormatterSinkProvider clientProv = new SoapClientFormatterSinkProvider();
            IDictionary props = new Hashtable(); 
            props["port"] = pc.Port;

            IChannel ch = null;
            switch (pc.ConnectionType)
            {
                case "http":
                    ch = new HttpChannel(props, clientProv, serverProv);
                    break;
                case "tcp":
                    ch = new TcpChannel(props, clientProv, serverProv);
                    break;
            }
            ChannelServices.RegisterChannel(ch);

            RemotingConfiguration.RegisterWellKnownServiceType(
                             typeof(Peer),"RemotePeer.soap",WellKnownObjectMode.Singleton);


            _peer = (Peer)Activator.GetObject(typeof(Peer),pc.PeerUri);
            _peer.SetForm(this);
            foreach (string music in pc.Musics){_peer.AddMusic(music);}
            foreach (string album in pc.Albuns){_peer.AddAlBum(album);}
            _peer.SetUri(pc.PeerUri);
            if (pc.AssociatedPeers != null)
                foreach (string p in pc.AssociatedPeers)
                {
                    _peer.AddPeer(p);
                }
        }

        private void addPeerBtn_Click(object sender, EventArgs e)
        {
            string peerToAdd = addPeerTextBox.Text;
            if (peerToAdd.Length == 0) return;
            _peer.AddPeer(peerToAdd);
        }

        private void searchMusicBtn_Click(object sender, EventArgs e)
        {
            string music = musicToSearchTextBox.Text;
            _peer.SearchMusic(music);
        }

        public void SetOutputMessage(string self)
        {
            syncCtx.Post(state => outputTextBox.AppendText(self + "\n"), null);
        }
        public void SetShowPeersTextBox(string self)
        {
            syncCtx.Post(state => showPeersTextBox.AppendText(self + "\n"), null);
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