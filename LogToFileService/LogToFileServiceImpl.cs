using LogManagerContract.DTO;
using LogManagerContract.DTO.Responses;
using LogManagerContract.DTO.Responses.CreateFileLogResponses;
using LogManagerContract.DTO.Responses.GetDBLogResponses;
using LogManagerContract.DTO.Responses.GetLogResponses;
using LogManagerContract.Interfaces;
using System;
using System.IO;
using System.Runtime.InteropServices.WindowsRuntime;

namespace LogToFileService
{
    public class LogToFileServiceImpl : ILoggerService
    {
        public Response CreateLog(CreateLogRequest request)
        {
           try
            {
            var retval = new Response();
            string logFilePath = @"C:\Logs\Log-" + System.DateTime.Today.ToString("MM-dd-yyyy") +" "+ System.DateTime.Now.ToString("HH-mm-ss") + "." + "txt";
            FileInfo logFileInfo = new FileInfo(logFilePath);
            DirectoryInfo logDirInfo = new DirectoryInfo(logFileInfo.DirectoryName);
            if (!logDirInfo.Exists) logDirInfo.Create();
                using (FileStream fileStream = new FileStream(logFilePath, FileMode.Append))
                {
                    using (StreamWriter log = new StreamWriter(fileStream))
                    {
                        log.WriteLine(request.LogData);
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
            var retval = new Response();
            try
            {
                var logFilePath = @"C:\Logs\" + request.LogName;
                

                using (StreamReader sr = new StreamReader(logFilePath))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        retval = new GetLogResponseOK(line);
                    }              
                }
                return retval;
            }
            catch (Exception ex)
            {
                if (ex.HResult == -2147024894)
                {
                    return new GetLogNotExistResponse();
                }
                return new AppResponseError(ex.Message);
            }

        }
    }
}
