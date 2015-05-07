using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Client
{

    public class Peer : MarshalByRefObject, IPeer
    {
        private readonly List<string> _myMusics = new List<string>();
        private readonly List<IPeer> _myKnownPeers = new List<IPeer>();
        private readonly Dictionary<string, IPeer> _musicsOnKnownPeers = new Dictionary<string, IPeer>();
        private string _xmlFile;
        private Form1 form;
        private string name;

        private const int ttl = 2;

        public void SearchMusic(string musicName)
        {
            SearchMusic(this, musicName, ttl);
        }
        public bool TestConnection() { return true; }
        public void SearchMusic(IPeer p, string musicName, int ttl)
        {
            SetOutputMsg("Request from " + p.GetPeerName());
            SetOutputMsg("Searching for music " + musicName);
            if (_myMusics.Contains(musicName))
            {
                p.MarkAsFound(this, musicName);
                return;
            }
            if (_musicsOnKnownPeers.ContainsKey(musicName))
            {
                IPeer peer = _musicsOnKnownPeers[musicName];
                try
                {
                    p.MarkAsFound(peer, musicName);
                }
                catch (Exception)
                {
                    SetOutputMsg("Peer to respond not found!!!");
                }
                return;
            }
            if (--ttl == 0) return;
            foreach (IPeer peer in _myKnownPeers)
            {
                try
                {
                    peer.SearchMusic(p, musicName, ttl);
                }
                catch (Exception)
                {
                    _myKnownPeers.Remove(peer);
                }

            }
        }
        public void MarkAsFound(IPeer p, string music)
        {
            if (!_musicsOnKnownPeers.ContainsKey(music))
            {
                _musicsOnKnownPeers.Add(music, p);
                form.SetOutputMessage("Found music in Peer " + p.GetPeerName());
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
            a.ToList().ForEach(m => _myMusics.Add(m));
        }
        public void AddPeer(int port)
        {
            IPeer p = (IPeer)Activator.GetObject(typeof(IPeer), "http://localhost:" + port + "/RemotePeer.soap");
            try
            {
                if (p.TestConnection()) _myKnownPeers.Add(p);
                SetShowPeersTextBox("" + p.GetPeerName());
            }
            catch (Exception){SetOutputMsg("Invalid peer params. Not added!!!");}
        }
        public void SetOutputComunication(Form1 form1){this.form = form1;}
        public string GetPeerName(){return name;}
        public void SetName(int port){this.name = port + "";}
        private void SetOutputMsg(string msg) { form.SetOutputMessage(msg); }
        private void SetShowPeersTextBox(string msg) { form.SetShowPeersTextBox(msg); }
    }

    public interface IPeer
    {
        bool TestConnection();
        void SearchMusic(IPeer p, string musicName, int ttl);
        void MarkAsFound(IPeer p, string music);
        string GetPeerName();
    }
}
