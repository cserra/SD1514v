using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using Interface;

namespace Client.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            string configfile = "Client.Console.exe.config";
            RemotingConfiguration.Configure(configfile, false);
            WellKnownClientTypeEntry[] entries = RemotingConfiguration.GetRegisteredWellKnownClientTypes();
            IBroker broker = (IBroker)Activator.GetObject(entries[0].ObjectType, entries[0].ObjectUrl);

            System.Console.WriteLine("Input:\n[exe path] [input file path] [output filepath]");
            System.Console.WriteLine("or [exit]");
            
            do{
                string input = System.Console.ReadLine();
                string[] tokens = input.Split(' ');
                if (tokens.Length < 3) break;
                //broker.SubmitJob(new JobCompletion(), tokens[1], tokens[2], tokens[0]);
                System.Console.WriteLine("Job submited");
            } while (true);
        }
    }
}
