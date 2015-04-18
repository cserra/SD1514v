using System;
using System.Collections;
using System.Diagnostics;
using System.IO;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;
using System.Runtime.Remoting.Channels.Ipc;
using System.Threading;
using Interface;

namespace Worker
{
    public class Program
    {
        public static void Main(string[] args)
        {
            const String configPath = "Worker.exe.config";
            string workerId = args[0];
            Console.WriteLine(workerId);

            // Registar o canal
            /*SoapServerFormatterSinkProvider serverProv = new SoapServerFormatterSinkProvider();
            serverProv.TypeFilterLevel = System.Runtime.Serialization.Formatters.TypeFilterLevel.Full;
            SoapClientFormatterSinkProvider clientProv = new SoapClientFormatterSinkProvider();
            IDictionary props = new Hashtable();
            props["port"] = Convert.ToInt32(workerId);*/

            //var http = new HttpChannel(props, clientProv, serverProv);
            var http = new HttpChannel(Convert.ToInt32(workerId));
            ChannelServices.RegisterChannel(http, false);
            
            // Registar nome do servidor
            // Registar o type Aluno como Client Activated Object (CAO)
            RemotingConfiguration.RegisterWellKnownServiceType(
                typeof(WorkerImpl),
                "Worker.soap",
                WellKnownObjectMode.Singleton);

            //RemotingConfiguration.Configure(configPath,false);

           /* WellKnownServiceTypeEntry[] arr = RemotingConfiguration.GetRegisteredWellKnownServiceTypes();
            foreach (WellKnownServiceTypeEntry wellKnownServiceTypeEntry in arr)
            {
                Console.WriteLine(wellKnownServiceTypeEntry+"\n"+ "Espera pedidos..");
            }*/
            Console.ReadLine();
        }
    }
}
