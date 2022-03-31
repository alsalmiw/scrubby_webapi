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
    public class SpaceCollectionController : ControllerBase
    {
        private readonly SpaceCollectionService _data;

        public SpaceCollectionController(SpaceCollectionService _dataFromService)
        {
            _data = _dataFromService;
        }

        [HttpPost("CreateSpaceCollection")]
        public bool CreateSpaceCollection(SpaceCollectionModel SpaceCollectionToCreate)
        {
            return _data.CreateSpaceCollection(SpaceCollectionToCreate);
        }
        [HttpGet("GetSpaceCollectionById/{Id}")]
        public SpaceCollectionModel GetSpaceCollectionById(int Id)
        {
            return _data.GetSpaceCollectionById(Id);
        }
        [HttpGet("GetSpaceCollectionByUserId/{UserId}")]
        public SpaceCollectionModel GetSpaceCollectionByUserId(int UserId)
        {
            return _data.GetSpaceCollectionByUserId(UserId);
        }
        [HttpPost("DeleteSpaceCollectionById/{Id}")]
        public bool DeleteSpaceCollectionById(int Id)
        {
            return _data.DeleteSpaceCollectionById(Id);
        }

        [HttpPost("UpdateSpaceCollectionNameByUserId/{UserId}/{CollectionName}")]
        public bool UpdateSpaceCollectionNameByUserId(int UserId, string CollectionName)
        {
            return _data.UpdateSpaceCollectionNameByUserId(UserId, CollectionName);
        }


    }
}