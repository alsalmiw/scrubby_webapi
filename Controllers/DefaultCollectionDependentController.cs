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
    public class DefaultCollectionDependentController: ControllerBase
    {

        private readonly DefaultCollectionDependentService _data;
        public DefaultCollectionDependentController (DefaultCollectionDependentService dataFromDefaultCollectionService)
        {
            _data = dataFromDefaultCollectionService;
        }

             [HttpGet("ChildDefaultSchedule/{ChildId}")]
        public ScheduleCollectionsDTO ChildDefaultSchedule(int childId)
        {
            return _data.ChildDefaultSchedule(childId);
        }

          [HttpPost("CreateChildDefaultSchedule")]
         public bool CreateChildDefaultSchedule(DefaultCollectionDependentModel newDefault)
        {
            return _data.CreateChildDefaultSchedule(newDefault);
        }
    }
}