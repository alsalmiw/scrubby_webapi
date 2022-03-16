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
    public class SpaceInfoController : ControllerBase
    {
        private readonly SpaceInfoService _data;

        public SpaceInfoController(SpaceInfoService dataFromService)
        {
            _data = dataFromService;
        }

        [HttpPost("AddNewSpace")]
        public bool AddNewSpace(SaceInfoModel newSpace)
        {
            return _data.AddNewSpace(newSpace);
        }

        [HttpGet("GetAllSpaces")]
        public IEnumerable<SpaceInfoModel> GetAllSpaces()
        {
            return _data.GetAllSpaces();
        }

        
    }
}