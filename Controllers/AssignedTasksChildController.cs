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
        [HttpPost("UpdateAssignedTasksChildByIdAndDateCom/{Id}/{DateCompleted}")]
        public bool UpdateAssignedTasksChildByIdAndDateCom(int Id, string? DateCompleted)
        {
            return _data.UpdateAssignedTasksChildByIdAndDateCom(Id, DateCompleted);
        }
        //update repeat
        [HttpPost("UpdateRepeatAssignedTasksChildByIdAndRepeat/{Id}/{Repeat}")]
        public bool UpdateRepeatAssignedTasksChildByIdAndRepeat(int Id, int Repeat)
        {
            return _data.UpdateRepeatAssignedTasksChildByIdAndRepeat(Id, Repeat);
        }

        [HttpGet("GetAssignedTasksChildById/{Id}")]
        public AssignedTasksChildModel GetAssignedTasksChildById(int Id)
        {
            return _data.GetAssignedTasksChildById(Id);
        }

        
        [HttpGet("GetAssignedTasksChildByUserId/{UserId}")]
        public IEnumerable<AssignedTasksChildModel> GetAssignedTasksChildByUserId(int UserId)
        {
            return _data.GetAssignedTasksChildByUserId(UserId);
        }


        [HttpPost("DeletedAssignedTasksChildById/{Id}")]
        public bool DeletedAssignedTasksChildById(int Id)
        {
             return _data.DeletedAssignedTasksChildById(Id);
        }

    }
}