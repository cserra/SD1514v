using System;
using Interface;

namespace Client
{
    public class JobCompletion : MarshalByRefObject, IJobCompletion
    {
        public enum Status
        {
            Submited,
            Terminated,
            Error
        };

        private Status _status = Status.Submited;

        public Status JobStatus
        {
            get { return _status; }
            set { _status = value; }
        }

        public void Terminated(int jobId)
        {
            _status = Status.Terminated;
        }

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