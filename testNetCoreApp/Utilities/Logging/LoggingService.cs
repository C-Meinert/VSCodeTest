using System;

namespace testNetCoreApp.Utilities.Logging
{
    /// <summary>
    /// 
    /// </summary>
    public class LoggingService : ILoggingService
    {
        /// <summary>
        /// 
        /// </summary>
        public LoggingService()
        {

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="msg"></param>
        public void Debug(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}