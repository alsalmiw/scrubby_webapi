using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using scrubby_webapi.Models;
using Microsoft.AspNetCore.Mvc;

namespace scrubby_webapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SelectedTaskController : ControllerBase
    {
        private readonly UserService _data;

        public UserController(UserService _dataFromService)
        {
            _data = _dataFromService;
        }
        [HttpGet("GetSelectedTaskById/{Id}")]
        public IEnumerable<SelectedTasksModel> GetSelectedTaskByUserId(int id)
        {
           return  _data.GetSelectedTaskUserById(id);
        }

        [HttpPost("UpdateSelectedTask")]
        public bool UpdateSelectedTask(SelectedTaskModel selectedTaskToUpdate)
        {
            return UpdateSelectedTask(selectedTaskToUpdate);
        }


    }
}