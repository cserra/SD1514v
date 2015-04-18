using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
    public interface IJobCompletion
    {
        void Terminated(int jobId);
        void Error(int jobId, String msg);
        void Results(int jobId);
    }
}
