using log4net;
using log4net.Appender;
using log4net.Config;
using log4net.Core;
using log4net.Filter;
using log4net.Layout;
using log4net.Repository;

namespace PrintForms.Helper
{
    public class LogDynamicCreate
    {
        private static readonly Dictionary<string, ILog> Logers = new Dictionary<string, ILog>();

        public static ILog GetLogger(string name)
        {
            if (Logers.ContainsKey(name))
                return Logers[name];
            else
            {
                lock (Logers)
                {
                    if (Logers.ContainsKey(name)) return Logers[name];
                    else
                    {
                        var newLoger = CreateLoger(name);
                        Logers.Add(name, newLoger);
                        return newLoger;
                    }
                }
            }
        }
        /// <summary>
        /// 创建Log实例
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private static ILog CreateLoger(string name)
        {
            // Pattern Layout
            //PatternLayout layout = new PatternLayout("%date{yyyy-MM-dd HH:mm:ss} %-5level[%L] %message% %F%newline");
            PatternLayout layout = new PatternLayout("%date{yyyy-MM-dd HH:mm:ss:fff} %-5level[%L] %message%newline");
            // Level Filter
            LevelMatchFilter filter = new LevelMatchFilter();
            filter.LevelToMatch = Level.All;
            filter.ActivateOptions();
            // File Appender
            RollingFileAppender appender = new RollingFileAppender();
            appender.File = $"logs\\{name}\\";
            appender.ImmediateFlush = true;
            appender.AppendToFile = true;
            appender.RollingStyle = RollingFileAppender.RollingMode.Composite;
            appender.PreserveLogFileNameExtension = true;
            appender.DatePattern = $"yyyyMMdd'.txt'";
            appender.LockingModel = new FileAppender.MinimalLock();
            appender.Name = $"{name}Appender";
            appender.AddFilter(filter);
            appender.Layout = layout;
            appender.ActivateOptions();
            appender.MaximumFileSize = "10MB";
            appender.MaxSizeRollBackups = 30;
            appender.StaticLogFileName = false;
            //create instance
            string repositoryName = $"{name}Repository";
            ILoggerRepository repository = LoggerManager.CreateRepository(repositoryName);
            BasicConfigurator.Configure(repository, appender);
            //After the log instance initialization, we can get the instance from the LogManager by the special log instance name. Then you can start your logging trip.
            ILog logger = LogManager.GetLogger(repositoryName, name);
            return logger;
        }

    }

}
