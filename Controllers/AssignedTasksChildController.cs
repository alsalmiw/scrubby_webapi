using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using scrubby_webapi.Models;
using scrubby_webapi.Services;

namespace scrubby_webapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AssignedTasksChildController : ControllerBase
    {
        private readonly AssignedTasksChildService _data;

        public AssignedTasksChildController(AssignedTasksChildService _dataFromService)
        {
            _data = _dataFromService;
        }

        [HttpPost("CreateAssignedTasksChild")]
        public bool CreateAssignedTasksChild(AssignedTasksChildModel AssignedTasksChildToCreate)
        {
            return _data.CreateAssignedTasksChild(AssignedTasksChildToCreate);
        }
        
        //update datecompleted
        [HttpPost("UpdateAssignedTasksChildByIdAndDateCom/{AssignedTaskId}/{DateCompleted}")]
        public bool UpdateAssignedTasksChildByIdAndDateCom(int AssignedTaskId, string? DateCompleted)
        {
            return _data.UpdateAssignedTasksChildByIdAndDateCom(AssignedTaskId, DateCompleted);
        }
        //update repeat
        [HttpPost("UpdateRepeatAssignedTasksChildByIdAndRepeat/{AssignedTaskId}/{Repeat}")]
        public bool UpdateRepeatAssignedTasksChildByIdAndRepeat(int AssignedTaskId, int Repeat)
        {
            return _data.UpdateRepeatAssignedTasksChildByIdAndRepeat(AssignedTaskId, Repeat);
        }

        [HttpGet("GetAssignedTasksChildById/{AssignedTaskId}")]
        public AssignedTasksChildModel GetAssignedTasksChildById(int AssignedTaskId)
        {
            return _data.GetAssignedTasksChildById(AssignedTaskId);
        }

        
        [HttpGet("GetAssignedTasksChildByUserId/{UserId}")]
        public AssignedTasksChildModel GetAssignedTasksChildByUserId(int UserId)
        {
            return _data.GetAssignedTasksChildByUserId(UserId);
        }


        [HttpPost("DeletedAssignedTasksChildById/{AssignedTaskId}")]
        public bool DeletedAssignedTasksChildById(int AssignedTaskId)
        {
             return _data.DeletedAssignedTasksChildById(AssignedTaskId);
        }

    }
}