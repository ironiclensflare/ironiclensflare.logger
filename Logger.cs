using System.Reflection;
using log4net;
using log4net.Appender;
using log4net.Layout;
using log4net.Repository.Hierarchy;

namespace ironiclensflare.logger
{
    public static class Logger
    {
        public static ILog GetLogger()
        {
            var logger = LogManager.GetLogger(Assembly.GetCallingAssembly().GetType());
            var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            
            var hierarchy = (Hierarchy)logRepository;
            hierarchy.Root.AddAppender(GetConsoleAppender());
            hierarchy.Configured = true;
            
            return logger;
        }

        private static IAppender GetConsoleAppender()
        {
            var consoleAppender = new ConsoleAppender();
            var layout = new PatternLayout { ConversionPattern = "%date %-5level %logger - %message%newline" };
            layout.ActivateOptions();
            consoleAppender.Layout = layout;

            return consoleAppender;
        }
    }
}