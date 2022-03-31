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
    public class AssignedTasksUsersController : ControllerBase
    {
        private readonly AssignedTasksUsersService _data;

        public AssignedTasksUsersController(AssignedTasksUsersService _dataFromService)
        {
            _data = _dataFromService;
        }

        [HttpGet("GetAllAssignedTasksUsersById/{Id}")]

        public IEnumerable<AssignedTasksUsersModel> GetAllAssignedTasksUsersById(int id)
        {
            return _data.GetAllAssignedTasksUsersById(id);
        }

        [HttpGet("GetDateCreatedAssignedTasksUsersById/{Id}")]

        public IEnumerable<AssignedTasksUsersModel> GetDateCreatedAssignedTasksUsersById(int id)
        {
            return _data.GetDateCreatedAssignedTasksUsersById(id);
        }

        [HttpGet("GetDateCompletedAssignedTasksUsersById/{Id}")]

        public IEnumerable<AssignedTasksUsersModel> GetDateCompletedAssignedTasksUsersById(int id)
        {
            return _data.GetDateCompletedAssignedTasksUsersById(id);
        }

        [HttpGet("GetAllAssignedTasksUsersByUserId/{userId}")]

        public IEnumerable<AssignedTasksUsersModel> GetAllAssignedTasksUsersByUserId(int userId)
        {
            return _data.GetAllAssignedTasksUsersByUserId(userId);
        }

        [HttpGet("GetDateCreatedAssignedTasksUsersByUserId/{userId}")]

        public IEnumerable<AssignedTasksUsersModel> GetDateCreatedAssignedTasksUsersByUserId(int userId)
        {
            return _data.GetDateCreatedAssignedTasksUsersByUserId(userId);
        }

        [HttpGet("GetDateCompletedAssignedTasksUsersByUserId/{userId}")]
        public IEnumerable<AssignedTasksUsersModel> GetDateCompletedAssignedTasksUsersByUserId(int userId)
        {
            return _data.GetDateCompletedAssignedTasksUsersByUserId(userId);
        }

        [HttpPost("UpdateAssignedTasksUsers/{Id}/{SelectedTasksId}")]

        public bool UpdateAssignedTasksUsers(int Id, int SelectedTasksId)
        {
            return _data.UpdateAssignedTasksUsers(Id, SelectedTasksId);
        }

        
        





        









        








    }
}