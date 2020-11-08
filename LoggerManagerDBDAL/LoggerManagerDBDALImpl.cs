using DALContracts;
using LogManagerContract.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Data;

namespace LoggerManagerDBDAL
{
    public class LoggerManagerDBDALImpl : ILoggerManagerDBDAL
    {
        IDBConnection _conn;
        IInfraDAL _infraDAL;
        IConfiguration _configuration;

        public LoggerManagerDBDALImpl(IInfraDAL infraDAL, IConfiguration configuration)
        {
            _infraDAL = infraDAL;
            _configuration = configuration;
            _conn = _infraDAL.Connect(_configuration.GetConnectionString("LoggerManager"));
        }
        public DataSet CreateLog(string dataLog, string date,string logName)
        {
            IDBParameter output = _infraDAL.getParameter("RETVAL", "RefCursor", ParameterDirection.Output);
            IDBParameter param1 = _infraDAL.getParameter("P_LOGCONTENT", "Varchar2", dataLog);
            IDBParameter param2 = _infraDAL.getParameter("P_CREATEDDATE", "Varchar2", date);
            IDBParameter param3 = _infraDAL.getParameter("P_LOGNAME", "Varchar2", logName);
            var retval = _infraDAL.ExecuteSPQuery(_conn, "CREATELOG", param1, param2, param3, output);
            return retval;
        }

        public DataSet GetLog(string logName)
        {
           IDBParameter output = _infraDAL.getParameter("RETVAL", "RefCursor", ParameterDirection.Output);
            IDBParameter param1 = _infraDAL.getParameter("P_LOGNAME", "Varchar2", logName);
            var retval = _infraDAL.ExecuteSPQuery(_conn, "GETLOG",param1, output);
            return retval;
        }


    }
}
