using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;
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
            portTextBox.ReadOnly = true;
            xmlFileTextBox.ReadOnly = true;
            addPeerTextBox.ReadOnly = false;
            musicToSearchTextBox.ReadOnly = false;

            int port = int.Parse(portTextBox.Text);
            string xmlFile;
            if ((xmlFile = xmlFileTextBox.Text) == null)
            {
                xmlFileTextBox.Text = "This field cannot be empty";
                return;
            }


            SoapServerFormatterSinkProvider serverProv = new SoapServerFormatterSinkProvider();
            serverProv.TypeFilterLevel = System.Runtime.Serialization.Formatters.TypeFilterLevel.Full;
            SoapClientFormatterSinkProvider clientProv = new SoapClientFormatterSinkProvider();
            IDictionary props = new Hashtable();
            props["port"] = port;
            HttpChannel ch = new HttpChannel(props, clientProv, serverProv);
            ChannelServices.RegisterChannel(ch, false);

            RemotingConfiguration.RegisterWellKnownServiceType(
                             typeof(Peer),"RemotePeer.soap",WellKnownObjectMode.Singleton);

            string a = "http://localhost:" + port + "/RemotePeer.soap";

            _peer = (Peer)Activator.GetObject(
                            typeof(Peer),
                            "http://localhost:" + port + "/RemotePeer.soap");

            _peer.setXML(xmlFile);
            _peer.SetOutputComunication(this);
            _peer.SetName(port);
        }

        private void addPeerBtn_Click(object sender, EventArgs e)
        {
            string peerToAdd = addPeerTextBox.Text;
            if (peerToAdd.Length == 0) return;
            int port = int.Parse(peerToAdd);
            _peer.AddPeer(port);
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
    }
}