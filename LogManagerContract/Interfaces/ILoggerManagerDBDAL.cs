using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace LogManagerContract.Interfaces
{
   public interface ILoggerManagerDBDAL
    {
        public DataSet CreateLog(string dataLog,string date, string logName);
        public DataSet GetLog(string logName);
    }
}
