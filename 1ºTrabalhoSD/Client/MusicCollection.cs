using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Client
{
    public class MusicCollectionManager
    {
        public void Save(Peer peer, String path)
        {
            // Create an instance of the XmlSerializer class; 
            // specify the type of object to serialize.
            XmlSerializer serializer = new XmlSerializer(typeof(Peer));
            TextWriter writer = new StreamWriter(path);
            serializer.Serialize(writer, peer);
            writer.Close();
        }

        public Peer Load(String path)
        {
            // Create an instance of the XmlSerializer class; 
            // specify the type of object to be deserialized.
            XmlSerializer serializer = new XmlSerializer(typeof(MusicCollection));
           // A FileStream is needed to read the XML document.
            FileStream fs = new FileStream(path, FileMode.Open);
            // Declare an object variable of the type to be deserialized.
            Peer peer;
            /* Use the Deserialize method to restore the object's state with
            data from the XML document. */
            peer = (Peer)serializer.Deserialize(fs);
            return peer;
        } 

    }

    [XmlRootAttribute("MusicCollection",IsNullable = false)]
    public class MusicCollection
    {
        [XmlAttribute()]
        public String MusicCollectionName;
        [XmlArray]
        public Music[] Musics;
    }

    public class Music
    {
        [XmlAttribute]
        public String MusicName;
        public Music(){}
        public Music(String name)
        {
            MusicName = name;
        }
    }
}
