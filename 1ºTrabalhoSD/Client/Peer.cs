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
        public List<string> MyMusics = new List<string>();
        public List<string> MyAlbum = new List<string>();
        public List<IPeer> MyKnownPeers = new List<IPeer>();
        private readonly Dictionary<string, IPeer> _musicsOnKnownPeers = new Dictionary<string, IPeer>();
        private string _xmlFile;
        private Form1 _form;
        public string Uri;
        public string ConnectionType;
        public string Port;

        private const int ttl = 2;

        public void SearchMusic(string musicName)
        {
            SearchMusic(this, musicName, ttl);
        }
        public bool TestConnection() { return true; }
        public void SearchMusic(IPeer p, string musicName, int ttl)
        {
            SetOutputMsg("Request from " + p.GetPeerURI());
            SetOutputMsg("Searching for music " + musicName);
            if (MyMusics.Contains(musicName))
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
            foreach (IPeer peer in MyKnownPeers)
            {
                try
                {
                    peer.SearchMusic(p, musicName, ttl);
                }
                catch (Exception)
                {
                    MyKnownPeers.Remove(peer);
                }

            }
        }
        public void MarkAsFound(IPeer p, string music)
        {
            if (!_musicsOnKnownPeers.ContainsKey(music))
            {
                _musicsOnKnownPeers.Add(music, p);
                _form.SetOutputMessage("Found music in Peer " + p.GetPeerURI());
            }
            
        }

        public string GetPeerURI(){return Uri;}
        private void SetOutputMsg(string msg) { _form.SetOutputMessage(msg); }
        private void SetShowPeersTextBox(string msg) { _form.SetShowPeersTextBox(msg); }

        public void AddMusic(string music){MyMusics.Add(music);}
        public void AddAlBum(string album){MyAlbum.Add(album);}
        public void SetUri(string peerUri){this.Uri = peerUri;}
        public void AddPeer(string peerUri)
        {
            IPeer p = (IPeer)Activator.GetObject(typeof(IPeer), peerUri);
            try
            {
                if (p.TestConnection()) MyKnownPeers.Add(p);
                SetShowPeersTextBox("" + p.GetPeerURI());
            }
            catch (Exception) { SetOutputMsg("Invalid peer params. Not added!!!"); }
        }

        public void SetForm(Form1 form1)
        {
            this._form = form1;
        }
    }

    public interface IPeer
    {
        bool TestConnection();
        void SearchMusic(IPeer p, string musicName, int ttl);
        void MarkAsFound(IPeer p, string music);
        string GetPeerURI();
    }
}
