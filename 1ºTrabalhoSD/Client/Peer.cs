using System;
using System.Collections.Generic;

namespace Client
{

    public class Peer : MarshalByRefObject, IPeer
    {
        public List<string> MyMusics = new List<string>();
        public List<string> MyAlbum = new List<string>();
        public List<IPeer> MyKnownPeers = new List<IPeer>();
        private readonly Dictionary<string, IPeer> _musicsOnKnownPeers = new Dictionary<string, IPeer>();
        private Form1 _form;
        public string Uri;
        public string ConnectionType;
        public string Port;
        public static readonly int Ttl = 2;

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
        public void SetForm(Form1 form1){_form = form1;}
        public void AddAssociatedPeer(string peerUri)
        {
            try
            {
                IPeer p = (IPeer) Activator.GetObject(typeof (IPeer), peerUri);
                if (p.TestConnection())
                    MyKnownPeers.Add(p);
                SetShowPeersTextBox("" + p.GetPeerURI());
            }
            catch (Exception e)
            {
                SetShowPeersTextBox("Error: " + e.Message);
            }
            
            
      
        }
    }
}
