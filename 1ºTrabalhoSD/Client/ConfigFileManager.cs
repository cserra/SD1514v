using System;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace Client
{
    public class ConfigFileManager
    {
        public static void Save(Peer peer, string path)
        {
            // Create an instance of the XmlSerializer class; 
            // specify the type of object to serialize.
            XmlSerializer serializer = new XmlSerializer(typeof(PeerConfig));
            TextWriter writer = new StreamWriter(path); // peer.path
            
            PeerConfig peerConfig = new PeerConfig();
            //TODO os AssociatePeers sao IPeer e tem de ser string
            //peerConfig.AssociatedPeers = peer.AssociatedPeers;
            peerConfig.Musics = peer.MyMusics.ToArray();
            peerConfig.PeerUri = peer.Uri;
            peerConfig.Port = peer.Port;
            peerConfig.Albuns = peer.MyAlbum.ToArray();
            peerConfig.ConnectionType = peer.ConnectionType;
            peerConfig.AssociatedPeers = peer.MyKnownPeers.Select( (m)=> m.GetPeerURI()).ToArray();
            serializer.Serialize(writer, peerConfig);
            writer.Close();
        }

        public static PeerConfig Load(String path)
        {
            // Create an instance of the XmlSerializer class; 
            // specify the type of object to be deserialized.
            XmlSerializer serializer = new XmlSerializer(typeof(PeerConfig));
            // A FileStream is needed to read the XML document.
            FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
            
            /* Use the Deserialize method to restore the object's state with
            data from the XML document. */
            return (PeerConfig)serializer.Deserialize(fileStream);
        }

        public static void BindPeerConfigToPeer(Form1 form, PeerConfig pc, Peer peer)
        {
            peer.SetForm(form);
            peer.SetUri(pc.PeerUri);
            
            if (pc.Musics != null)
                foreach (string music in pc.Musics) { peer.AddMusic(music); }
            
            if (pc.Albuns != null)
                foreach (string album in pc.Albuns) { peer.AddAlBum(album); }
            
            if (pc.AssociatedPeers != null)
                foreach (string p in pc.AssociatedPeers){peer.AddAssociatedPeer(p);}
        }
    }

    [XmlRootAttribute("PeerConfig",IsNullable = false)]
    public class PeerConfig
    {
        [XmlAttribute]
        public String PeerUri;
        [XmlAttribute]
        public String ConnectionType;
        [XmlAttribute]
        public String Port;
        [XmlArray]
        public String[] Musics;
        [XmlArray]
        public String[] Albuns;
        [XmlArray]
        public String[] AssociatedPeers;

    }
}
