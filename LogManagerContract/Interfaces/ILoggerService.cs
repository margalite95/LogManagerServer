using LogManagerContract.DTO;
using LogManagerContract.DTO.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogManagerContract.Interfaces
{
   public interface ILoggerService
    {
        Response CreateLog(CreateLogRequest request);
        Response GetLog(GetLogRequest request);
    }
}
