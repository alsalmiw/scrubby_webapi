using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using scrubby_webapi.Services;
using scrubby_webapi.Models.Static;

namespace scrubby_webapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SpaceItemsStaticAPIController : ControllerBase
    {
         private readonly SpaceItemsStaticAPIService _data;

        public SpaceItemsStaticAPIController(SpaceItemsStaticAPIService _dataFromService)
        {
            _data = _dataFromService;
        }
        [HttpGet("GetSpaceItemsStaticAPIByTags/{Tags}")]
        public IEnumerable<SpaceItemsStaticAPIModel> GetSpaceItemsStaticAPIByTags(string Tags)
        {
            return _data.GetSpaceItemsStaticAPIByTags(Tags);
        }
    }
}