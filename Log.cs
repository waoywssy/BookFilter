using System;
using System.Collections.Generic;
using System.Text;
using NLog;

namespace eBookFilter
{
    public class Log
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public static void Info(string msg)
        {
            logger.Info(msg);
        }

        public static void Warn(string msg)
        {
            logger.Warn(msg);
        }

        public static void Error(string msg)
        {
            logger.Error(msg);
        }
    }
}
