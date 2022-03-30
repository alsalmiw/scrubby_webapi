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
        [HttpGet("GetSpaceCollectionById/{CollectionId}")]
        public SpaceCollectionModel GetSpaceCollectionById(int CollectionId)
        {
            return _data.GetSpaceCollectionById(CollectionId);
        }
        [HttpGet("GetSpaceCollectionByUserId/{UserId}")]
        public SpaceCollectionModel GetSpaceCollectionByUserId(int UserId)
        {
            return _data.GetSpaceCollectionByUserId(UserId);
        }
        [HttpPost("DeleteSpaceCollectionByCollectionId/{CollectionId}")]
        public bool DeleteSpaceCollectionByCollectionId(int CollectionId)
        {
            return _data.DeleteSpaceCollectionByCollectionId(CollectionId);
        }

    }
}