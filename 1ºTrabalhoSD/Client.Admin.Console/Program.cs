using System;
using System.Collections.Generic;
using System.Runtime.Remoting;
using Interface;

namespace Client.Admin.Console
{
    public class Program
    {
        private static void Main(string[] args)
        {
            string configfile = "Client.Admin.Console.exe.config";
            RemotingConfiguration.Configure(configfile, false);
            WellKnownClientTypeEntry[] entries = RemotingConfiguration.GetRegisteredWellKnownClientTypes();
            IBroker robj = (IBroker)Activator.GetObject(entries[0].ObjectType, entries[0].ObjectUrl);

            System.Console.WriteLine("[l]aunch [max jobs]");
            System.Console.WriteLine("[t]erminate [id]");
            System.Console.WriteLine("[q]uit");
            var workerIds = new List<int>();
            do{
                string input = System.Console.ReadLine();
                string[] tokens = input.Split(' ');
                if (tokens.Length <= 1) break;
                switch (tokens[0][0])
                {
                    case 'l':
                        int newid = robj.LaunchWorker(int.Parse(tokens[1]));
                        workerIds.Add(newid);
                        break;
                    case 't':
                        int id = int.Parse(tokens[1]);
                        robj.RemoveWorker(id);
                        workerIds.Remove(id);
                        break;
                }
                ShowIds(workerIds);
            } while (true);


        }

        private static void ShowIds(List<int> workerIds)
        {
            foreach (var workerId in workerIds)
            {
                System.Console.Write(workerId + " ");
            }
        }
    }
}