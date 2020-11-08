using System;
using System.Collections.Generic;
using System.Text;

namespace LogManagerContract.DTO.Responses
{
   public class Response
    {
        public string ResponseType { get; set; }
        public Response()
        {
            ResponseType = this.GetType().Name;
        }
    }
}
