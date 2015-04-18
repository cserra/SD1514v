using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interface;

namespace Client
{
    public class JobCompletion : MarshalByRefObject, IJobCompletion
    {

        Status _status = Status.Submited;

        enum Status { Submited, Terminated, Error};

        public void Terminated(int jobId)
        {
            _status = Status.Terminated;
        }
        //TODO: TIAGO!!!!!!!!!!!!!!!DONT FORGET!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        public void Error(int jobId, String msg)
        {
           _status = Status.Error;
        }

        public void Results(int jobId) //diferença para terminated?
        {
            _status = Status.Terminated;
        }
    }
}
