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
    [Route("api/[controller]")]
    public class SelectedItemsInSpaceController : ControllerBase
    {
        private readonly SelectedItemsInSpaceService _data;

        public SelectedItemsInSpaceController(SelectedItemsInSpaceService _dataFromService)
        {
            _data = _dataFromService;
        }
        [HttpGet("SelectedItemsInSpace/{Id}")]
        public IEnumerable<SelectedItemsInSpaceModel> GetSelectedTaskByUserId(int id)
        {
           return  _data.GetSelectedTaskUserById(id);
        }
    }
}