using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using scrubby_webapi.Services;
using scrubby_webapi.Models;

namespace scrubby_webapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SharedSpacesController : ControllerBase
    {
        private readonly SharedSpacesService _data;

        public SharedSpacesController(SharedSpacesService _dataFromService)
        {
            _data = _dataFromService;
        }

        [HttpPost("CreateSharedSpaces")]
        public bool CreateSharedSpaces(SharedSpacesModel spaceToCreate)
        {
            return _data.CreateSharedSpaces(spaceToCreate);
            
        }
        [HttpPost("DeleteSharedSpacesById/{Id}")]
        public bool DeleteSharedSpacesById(int Id)
        {
            return _data.DeleteSharedSpacesById(Id);
        }

        //missing update



        [HttpGet("GetSharedSpacesById/{Id}")]
        public SharedSpacesModel GetSharedSpacesById(int Id)
        {
            return _data.GetSharedSpacesById(Id);
        }
        [HttpGet("GetSharedSpacesByUserId/{UserId}")]
        public IEnumerable<SharedSpacesModel> GetSharedSpacesByUserId(int UserId)
        {
            return _data.GetSharedSpacesByUserId(UserId);
        }

        [HttpGet("GetSharedSpacesByInvitedAndInviterUsername/{InvitedUsername}/{InviterUsername}")]
        public IEnumerable<SharedSpacesModel> GetSharedSpacesByInvitedAndInviterUsername(string InvitedUsername, string InviterUsername)
        {
            return _data.GetSharedSpacesByInvitedAndInviterUsername(InvitedUsername, InviterUsername);
        }
    }
}