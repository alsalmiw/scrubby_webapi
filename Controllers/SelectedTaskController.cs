using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using scrubby_webapi.Models;
using Microsoft.AspNetCore.Mvc;
using scrubby_webapi.Services;
using scrubby_webapi.Models.DTO;
using scrubby_webapi.Models.Static;

namespace scrubby_webapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SelectedTaskController : ControllerBase
    {
        private readonly SelectedTasksService _data;

        public SelectedTaskController(SelectedTasksService _dataFromService)
        {
            _data = _dataFromService;
        }
        [HttpGet("GetSelectedTaskById/{Id}")]
        public IEnumerable<SelectedTasksModel> GetSelectedTaskById(int Id)
        {
           return  _data.GetSelectedTaskById(Id);
        }

         [HttpGet("GetSelectedTaskByUserId/{userId}")]
        public IEnumerable<SelectedTasksModel> GetSelectedTaskByUserId(int userId)
        {
           return  _data.GetSelectedTaskByUserId(userId);
        }

          [HttpGet("GetAllSelectedTasks")]
        public IEnumerable<SelectedTasksModel> GetAllSelectedTasks()
        {
           return  _data.GetAllSelectedTasks();
        }

        [HttpPost("UpdateSelectedTask")]
        public bool UpdateSelectedTask(SelectedTasksModel selectedTaskToUpdate)
        {
            return _data.UpdateSelectedTask(selectedTaskToUpdate);
        }
        [HttpPost("AddSelectedTask")]
        public bool AddSelectedTask(List<SelectedTaskDTO> listOfSelectedTask)
        {
            return _data.AddSelectedTask(listOfSelectedTask);
        }

     [HttpGet("getTasks/{name}")]
        public IEnumerable<TasksInfoStaticAPIModel> getTasks (string? name)
        {
            return _data.getTasks(name);
        }

 [HttpGet("GetTasksByUserID/{userID}")]
         public IEnumerable<TasksInfoStaticAPIModel> getTasksByUserID(int userID)
        {
            return _data.getTasksByUserID(userID);
        }

        [HttpGet("GetTasksBySpaceId/{spaceId}")]
         public List<SelectedTasksDTO> GetTasksBySpaceId(int spaceId)
        {
            return _data.GetTasksBySpaceId(spaceId);
        }

    }
}