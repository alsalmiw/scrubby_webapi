using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using scrubby_webapi.Services;
using scrubby_webapi.Models;
using Microsoft.AspNetCore.Mvc;
using scrubby_webapi.Models.DTO;


namespace scrubby_webapi.Models
{
        [ApiController]
        [Route("[controller]")]
    public class DefaultCollectionController: ControllerBase
    {

        private readonly DefaultCollectionService _data;
        public DefaultCollectionController (DefaultCollectionService dataFromDefaultCollectionService)
        {
            _data = dataFromDefaultCollectionService;
        }

             [HttpGet("UserDefaultSchedule/{username}")]
        public ScheduleCollectionsDTO UserDefaultSchedule(string username)
        {
            return _data.UserDefaultSchedule(username);
        }
    }
}