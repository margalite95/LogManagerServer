using System;
using System.Collections.Generic;
using System.Text;

namespace LogManagerContract.DTO
{
   public class CreateLogRequest
    {
        public string LogType { get; set; }
        public string LogData { get; set; }
      
    }
}
