using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using scrubby_webapi.Services.Context;

namespace scrubby_webapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TasksInfoStaticAPIController : ControllerBase
    {
         private readonly  TasksInfoStaticAPIService _data;

        public TasksInfoStaticAPIController( TasksInfoStaticAPIService _dataFromService)
        {
            _data = _dataFromService;
        }
    }
}