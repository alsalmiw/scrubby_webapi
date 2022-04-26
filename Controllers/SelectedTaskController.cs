using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using scrubby_webapi.Models;
using Microsoft.AspNetCore.Mvc;
using scrubby_webapi.Services;
using scrubby_webapi.Models.DTO;

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
        public IEnumerable<SelectedTasksModel> GetSelectedTaskByUserId(int id)
        {
           return  _data.GetSelectedTaskByUserId(id);
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
//

    }
}