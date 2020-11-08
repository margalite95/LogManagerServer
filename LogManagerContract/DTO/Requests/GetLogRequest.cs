using System;
using System.Collections.Generic;
using System.Text;

namespace LogManagerContract.DTO
{
   public class GetLogRequest
    {
        public string LogType { get; set; }
        public string LogName { get; set; }
    }
}
