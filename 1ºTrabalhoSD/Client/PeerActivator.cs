using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public class PeerActivator
    {
        public static Peer NewPeer(string port, string uri)
        {
            #region CreateServer
            SoapServerFormatterSinkProvider serverProv = new SoapServerFormatterSinkProvider();
            serverProv.TypeFilterLevel = System.Runtime.Serialization.Formatters.TypeFilterLevel.Full;
            #endregion

            #region CreateClient
            SoapClientFormatterSinkProvider clientProv = new SoapClientFormatterSinkProvider();
            #endregion

            #region CreateChannel
            IDictionary props = new Hashtable(); 
            props["port"] = port;
            
            /*
             *****Code for add multichannels******
             * 
             * 
            IChannel ch = null;
            switch (pc.ConnectionType)
            {
                case "http":
                    ch = new HttpChannel(props, clientProv, serverProv);
                    break;
                case "tcp":
                    ch = new TcpChannel(props, clientProv, serverProv);
                    break;
            }
            */

            IChannel ch = new HttpChannel(props, clientProv, serverProv);
            ChannelServices.RegisterChannel(ch);
            #endregion

            //Registers an object Type on the service end as a well-known type
            RemotingConfiguration.RegisterWellKnownServiceType(
                             typeof(Peer),"RemotePeer.soap",WellKnownObjectMode.Singleton);
            
            //Creates a proxy for a well-known object 
            return (Peer)Activator.GetObject(typeof(Peer),uri);
         }
    }
}
