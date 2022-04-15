using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using scrubby_webapi.Services.Context;
using scrubby_webapi.Models.Static;

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
        [HttpGet("GetTasksInfoStaticAPIById/{Id}")]
        public TasksInfoStaticAPIModel GetTasksInfoStaticAPIById(int Id)
        {
            return _data.GetTasksInfoStaticAPIById(Id);
        }
        [HttpGet("GetTasksInfoStaticAPIByTags/{Tags}")]
        public IEnumerable<TasksInfoStaticAPIModel> GetTasksInfoStaticAPIByTags(string Tags)
        {
            return _data.GetTasksInfoStaticAPIByTags(Tags);
        }

    }
}