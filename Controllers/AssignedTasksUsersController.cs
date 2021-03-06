using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using scrubby_webapi.Models;
using scrubby_webapi.Models.DTO;
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

        [HttpGet("GetAllAssignedTasksById/{Id}")]

        public AssignedTasksUsersModel GetAllAssignedTasksById(int id)
        {
            return _data.GetAllAssignedTasksById(id);
        }

          [HttpPost("AddUserAssignedTasks")]
        public bool AddUserAssignedTasks(List<AssignedTasksUsersModel> listOfAssignedTasks)
        {
            return _data.AddUserAssignedTasks(listOfAssignedTasks);
        }

        [HttpPost("DeleteAssignedTaskUserByTaskId/{Id}")]

          public bool DeleteAssignedTaskUserByTaskId(int Id)
        {
             return _data.DeleteAssignedTaskUserByTaskId(Id);
        }
        //missing service

        [HttpGet("GetDateCreatedAssignedTasksUsersById/{Id}")]

        public AssignedTasksUsersModel GetDateCreatedAssignedTasksUsersById(int Id)
        {
            return _data.GetDateCreatedAssignedTasksUsersById(Id);
        }

        [HttpGet("GetDateCompletedAssignedTasksUsersById/{Id}")]

        public AssignedTasksUsersModel GetDateCompletedAssignedTasksUsersById(int Id)
        {
            return _data.GetDateCompletedAssignedTasksUsersById(Id);
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

        [HttpPost("UpdateUserTaskToCompleted/{TaskId}")]

        public bool UpdateUserTaskToCompleted(int TaskId)
        {
            return _data.UpdateUserTaskToCompleted(TaskId);
        }






    }
}