using LogManagerContract.DTO;
using LogManagerContract.DTO.Responses;
using LogManagerContract.DTO.Responses.CreateFileLogResponses;
using LogManagerContract.DTO.Responses.GetDBLogResponses;
using LogManagerContract.Interfaces;
using System;

namespace LogToDBService
{
    public class LogToDBServiceImpl : ILoggerService
    {
        ILoggerManagerDBDAL _dal;
        public LogToDBServiceImpl(ILoggerManagerDBDAL dal)
        {
            _dal = dal;
        }
        public Response CreateLog(CreateLogRequest request)
        {
            try
            {
                var date = System.DateTime.Today.ToString("yyyy-MM-dd");
                var logName = System.DateTime.Today.ToString("MM-dd-yyyy") + " " + System.DateTime.Now.ToString("HH-mm-ss") + "." + "txt";
                var ds = _dal.CreateLog(request.LogData,date,logName);

                var tbl = ds.Tables[0];
                var retval = new Response();
                if (tbl.Rows.Count == 1)
                {
                    if (request.LogData == (string)tbl.Rows[0][0])
                    {
                        retval = new CreateLogResponsesOK();
                    }

                }
                return retval;
            }
            catch (Exception ex)
            {
                return new AppResponseError(ex.Message);
            }

        }

        public Response GetLog(GetLogRequest request)
        {
            try
            {           
                var ds = _dal.GetLog(request.LogName);
                var tbl = ds.Tables[0];
                var retval = new Response();
                if (tbl.Rows.Count == 1)
                {
                   retval = new GetLogResponseOK((string)tbl.Rows[0][0]);
                }
                return retval;
            }
            catch (Exception ex)
            {
                return new AppResponseError(ex.Message);
            }
        }
    }
}
