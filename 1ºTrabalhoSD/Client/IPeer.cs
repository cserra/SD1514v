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
        void MarkAsFound(IPeer p, string music);
        string GetPeerURI();
    }
}
