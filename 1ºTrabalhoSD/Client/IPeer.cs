using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public interface IPeer
    {
        bool TestConnection();
        void SearchMusic(IPeer p, string musicName, int ttl);
        void SearchAlbum(IPeer p, string albumName, int ttl);
        void MarkAsFoundMusic(IPeer p, string music);
        void MarkAsFoundAlbum(IPeer p, string album);
        string GetPeerURI();
    }
}
