using System;

namespace Interface
{
    public interface IWorker
    {
        void SubmitJob(IJobCompletion jb, int jobId ,string inputFile, string outputFile, string exeFile);
        int GetJobCount();
        double GetAverageTime();
        int GetId();
        int GetMaxJobs();
        void Initialize(int id, int maxJobs, int jobTimeout);
    }
}
