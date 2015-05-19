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
        private readonly Dictionary<string, IPeer> _albumOnKnownPeers = new Dictionary<string, IPeer>();
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
                p.MarkAsFoundMusic(this, musicName);
                return;
            }
            if (_musicsOnKnownPeers.ContainsKey(musicName))
            {
                IPeer peer = _musicsOnKnownPeers[musicName];
                try
                {
                    p.MarkAsFoundMusic(peer, musicName);
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
        public void SearchAlbum(IPeer p, string album, int ttl)
        {
            SetOutputMsg("Request from " + p.GetPeerURI());
            SetOutputMsg("Searching for album " + album);
            if (MyAlbum.Contains(album))
            {
                p.MarkAsFoundAlbum(this, album);
                return;
            }
            if (_albumOnKnownPeers.ContainsKey(album))
            {
                IPeer peer = _albumOnKnownPeers[album];
                try
                {
                    p.MarkAsFoundAlbum(peer, album);
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
                    peer.SearchAlbum(p, album, ttl);
                }
                catch (Exception)
                {
                    MyKnownPeers.Remove(peer);
                }

            }
        }
        public void MarkAsFoundMusic(IPeer p, string music)
        {
            try
            {
                p.TestConnection();
            }
            catch (Exception e)
            {
                return;             //does nothing becouse p is no longer valid
            }
            if (!_musicsOnKnownPeers.ContainsKey(music))
            {
                _musicsOnKnownPeers.Add(music, p);
                _form.SetOutputMessage("Found music in Peer " + p.GetPeerURI());
            }
            
        }
        public void MarkAsFoundAlbum(IPeer p, string album)
        {
            try
            {
                p.TestConnection();
            }
            catch (Exception e)
            {
                return;             //does nothing becouse p is no longer valid
            }
            if (!_albumOnKnownPeers.ContainsKey(album))
            {
                _albumOnKnownPeers.Add(album, p);
                _form.SetOutputMessage("Found album in Peer " + p.GetPeerURI());
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
