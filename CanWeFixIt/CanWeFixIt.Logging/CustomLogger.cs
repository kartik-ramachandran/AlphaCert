﻿using NLog;

namespace CanWeFixIt.Logging
{
    public class CustomLogger : ICustomLogger
    {
        private readonly Logger logger;

        public CustomLogger()
        {
            logger = LogManager.GetCurrentClassLogger();
        }

        public void LogInfo(string message)
        {
            logger.Info(message);
        }
    }

}
