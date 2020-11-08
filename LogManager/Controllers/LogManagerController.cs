using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LogManagerContract.DTO;
using LogManagerContract.DTO.Responses;
using LogManagerContract.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LogManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogManagerController : ControllerBase
    {
        ILoggerServiceFactory _service;

        public LogManagerController(ILoggerServiceFactory service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("CreateLog")]
        public Response CreateLog([FromBody] CreateLogRequest request)
        {
            var serviceCreated = _service.Create(request.LogType);
            return serviceCreated.CreateLog(request);
        }

        [HttpPost]
        [Route("GetLog")]
        public Response GetLog([FromBody] GetLogRequest request)
        {
            var serviceCreated = _service.Create(request.LogType);
            return serviceCreated.GetLog(request);
        }


       
    }
}
