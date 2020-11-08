using System;
using System.Collections.Generic;
using System.Text;

namespace LogManagerContract.Interfaces
{
   public interface ILoggerServiceFactory
    {
        ILoggerService Create(string logType);

    }
}
