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
    public class SpaceInfoController : ControllerBase
    {
        private readonly SpaceInfoService _data;

        public SpaceInfoController(SpaceInfoService dataFromService)
        {
            _data = dataFromService;
        }

        [HttpPost("AddNewSpace")]
        public bool AddNewSpace(SpaceInfoModel newSpace)
        {
            return _data.AddNewSpace(newSpace);
        }

        [HttpGet("GetAllSpaces")]
        public IEnumerable<SpaceInfoModel> GetAllSpaces()
        {
            return _data.GetAllSpaces();
        }
    

        [HttpGet("GetSpacesByCollectionID/{id}")]
        public IEnumerable<SpaceInfoModel> GetSpacesByCollectionID(int id)
        {
            return _data.GetSpacesByCollectionID(id);
        }
    
     [HttpGet("GetSpacesDTOByID/{id}")]
        public SpacesDTO GetSpacesDTOByID(int id)
        {
            return _data.GetSpacesDTOByID(id);
        }
    

        
    }
}