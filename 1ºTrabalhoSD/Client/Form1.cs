using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;
using System.Windows.Forms;

namespace Client
{
    public partial class Form1 : Form
    {
        private static int pos = 0;
        private Peer _peer;

        public Form1()
        {
            InitializeComponent();
        }

        private void CreatePeerBtn_Click(object sender, EventArgs e)
        {
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

            showPeersTextBox.Text = a;

            _peer.setXML(xmlFile);
            _peer.set(port);


        }

        private void addPeerBtn_Click(object sender, EventArgs e)
        {
            int port = int.Parse(addPeerTextBox.Text);
            _peer.AddPeer(port);
        }

        private void searchMusicBtn_Click(object sender, EventArgs e)
        {
            string music = musicToSearchTextBox.Text;
            _peer.SearchMusic(music);
        }
    }

    public class Peer : MarshalByRefObject, IPeer
    {
        private readonly List<string> _myMusics = new List<string>();
        private readonly List<IPeer> _myKnownPeers = new List<IPeer>();
        private readonly Dictionary<string, IPeer> _musicsOnKnownPeers = new Dictionary<string, IPeer>();
        private string _xmlFile;
        private int name;

        public void SearchMusic(string musicName)
        {
            SearchMusic(this, musicName);
        }

        public void SearchMusic(IPeer p, string musicName)
        {
            if(_myMusics.Contains(musicName))
            {
                //ja tem no proprio
                return;
            }
            if (_musicsOnKnownPeers.ContainsKey(musicName))
            {
                //sei quem tem
                IPeer peer = _musicsOnKnownPeers[musicName];
                p.MarkAsFound(peer, musicName);
                return;
            }
            foreach (IPeer peer in _myKnownPeers)
            {
                peer.SearchMusic(p, musicName);
            }
        }

        public void MarkAsFound(IPeer p, string music)
        {
            if (!_musicsOnKnownPeers.ContainsKey(music))
            {
                _musicsOnKnownPeers.Add(music, p);
            }
        }

        public void setXML(string xmlFile)
        {
            _xmlFile = xmlFile;
            loadMyMusics();
        }

        private void loadMyMusics()
        {
            string[] a = _xmlFile.Split(';');
            a.ToList().ForEach( m => _myMusics.Add(m));
        }

        public void AddPeer(int port)
        {
            string a = "http://localhost:" + port + "/RemoteServer.soap";

            IPeer p = (IPeer)Activator.GetObject(
                            typeof(IPeer),
                            "http://localhost:" + port + "/RemoteServer.soap");
            _myKnownPeers.Add(p);
        }

        public void set(int port)
        {
            this.name = port;
        }
    }

    public interface IPeer
    {
        void SearchMusic(IPeer p, string musicName);
        void MarkAsFound(IPeer p, string music);
    }
}