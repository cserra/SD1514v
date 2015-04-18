using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Interface
{
    public interface IBroker
    {
        int SubmitJob(IJobCompletion jb, String input, String output, String pathExe);
        int LaunchWorker(int maxJobs);
        bool RemoveWorker(int idJob);
    }
}
