using ApiJob.Models;

namespace ApiJob.Global
{
    public class Config
    {
        public static List<Job> tempLisJob = new List<Job>();

    }
        public enum ErrorCode
        {
            UnhandledException = 1,
            UnknownError = 2,
            JobNotFoundError = 3
        }
    
}
