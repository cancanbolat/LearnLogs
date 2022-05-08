using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Logging
{
    public class MyCustomLoggerFactory : ILoggerProvider
    {
        public ILogger CreateLogger(string categoryName)
        {
            return new MyCustomLogger();
        }

        public void Dispose()
        {

        }
    }

    public class MyCustomLogger : ILogger
    {
        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            // log seviyesi kontrolü
            return true;
        }

        // log mesajı burada ayarlanıyor
        // burada konsola mı dosyaya mı veya başka bir yere basıldığını ayarlayabilirsin.
        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            string logMsg = formatter(state, exception);

            logMsg = $"[{DateTime.Now:dd.MM.yyyy HH:mm:ss}] -> {logMsg}";

            Console.WriteLine(logMsg);
        }
    }
}
