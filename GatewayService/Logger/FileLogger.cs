﻿namespace GatewayService.Logger
{
    public class FileLogger : ILogger
    {
        private string filePath;
        private static object _lock = new object();
        public FileLogger(string path)
        {
            filePath = path;
        }
        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (formatter != null)
            {
                lock (_lock)
                {
                    File.AppendAllText(filePath, formatter(state, exception) + Environment.NewLine);
                }
            }
        }

        public void LogWarning<TState>(string exText)
        {
            lock (_lock)
            {
                File.AppendAllText(filePath, "WARN        : " + exText + Environment.NewLine);
            }
        }
        public void LogInformation<TState>(string exText)
        {
            lock (_lock)
            {
                File.AppendAllText(filePath, "INFO        : " + exText + Environment.NewLine);
            }
        }
    }
}
