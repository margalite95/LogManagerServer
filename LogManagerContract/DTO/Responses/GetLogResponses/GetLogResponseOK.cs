using System;
using System.Collections.Generic;
using System.Text;

namespace LogManagerContract.DTO.Responses.GetDBLogResponses
{
   public class GetLogResponseOK:Response
    {
        public string LogData { get; set; }

        public GetLogResponseOK(string _logData)
        {
            LogData = _logData;
        }
    }
}
