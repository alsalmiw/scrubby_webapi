using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace scrubby_webapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SelectedItemsInSpaceController : ControllerBase
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
    }
}