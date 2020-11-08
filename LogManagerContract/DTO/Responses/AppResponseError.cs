using System;
using System.Collections.Generic;
using System.Text;

namespace LogManagerContract.DTO.Responses
{
    public class AppResponseError : Response
    {
        public AppResponseError(string msg)
        {
            Message = msg;
        }
        public string Message { get; }
    }
}
