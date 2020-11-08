using LogManagerContract.Interfaces;
using LogToDBService;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using LogToFileService;

namespace LoggerServiceFactory
{
    public class LoggerServiceFactoryImpl : ILoggerServiceFactory
    {
        private readonly Dictionary<string, ILoggerService> _services
       = new Dictionary<string, ILoggerService>(StringComparer.OrdinalIgnoreCase);

        public LoggerServiceFactoryImpl(IServiceProvider serviceProvider)
        {
            _services.Add("DB", serviceProvider.GetService<LogToDBServiceImpl>());
            _services.Add("File", serviceProvider.GetService<LogToFileServiceImpl>());


        }

        public ILoggerService Create(string logType)
        {
            return _services.ContainsKey(logType) ? _services[logType] :null;
        }
    }
}
