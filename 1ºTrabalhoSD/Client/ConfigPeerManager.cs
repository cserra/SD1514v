using System;
using System.IO;
using System.Xml.Serialization;

namespace Client
{
    public class ConfigFileManager
    {
        public void Save(Peer peer)
        {
            // Create an instance of the XmlSerializer class; 
            // specify the type of object to serialize.
            XmlSerializer serializer = new XmlSerializer(typeof(Peer));
            TextWriter writer = new StreamWriter(""); // peer.path
            
            PeerConfig peerConfig = new PeerConfig();
            peerConfig.AssociatedPeers = peer.AssociatedPeers;
            peerConfig.Musics = peer.mymusic;
            peerConfig.PeerUri = peer.uri;
            serializer.Serialize(writer, peerConfig);
            writer.Close();
        }

        public bool Load(ref Peer peer, String path)
        {
            // Create an instance of the XmlSerializer class; 
            // specify the type of object to be deserialized.
            XmlSerializer serializer = new XmlSerializer(typeof(PeerConfig));
           // A FileStream is needed to read the XML document.
            FileStream fs = new FileStream(path, FileMode.Open);
            // Declare an object variable of the type to be deserialized.
            PeerConfig peerConfig;
            /* Use the Deserialize method to restore the object's state with
            data from the XML document. */
            peerConfig = (PeerConfig)serializer.Deserialize(fs);
            peer.AssociatedPeers = peerConfig.AssociatedPeers;
            peer.mymusic = peerConfig.Musics;
            peer.uri = peerConfig.PeerUri;
            
            return true;
        } 

    }

    [XmlRootAttribute("MusicCollection",IsNullable = false)]
    public class PeerConfig
    {
        [XmlAttribute()]
        public String PeerUri;
        [XmlArray]
        public String[] Musics;
        [XmlArray]
        public String[] AssociatedPeers;

    }
}
