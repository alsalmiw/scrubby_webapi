using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using scrubby_webapi.Services;
using scrubby_webapi.Models;
using scrubby_webapi.Models.DTO;

namespace scrubby_webapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InviteUsersController : Controller
    {
        private readonly InviteUsersService _data;
        public InviteUsersController(InviteUsersService dataFromInviteService)
        {
            _data = dataFromInviteService;
        }
        [HttpPost("InviteUser")]
        public bool InviteUser (InviteUsersModel newUser)
        {
            return _data.InviteUser(newUser);
        }

        [HttpPost("AcceptInvite/{userId}/{invitedUsername}")]
        public bool AcceptInvite (int userId, string? invitedUsername)
        {
            return _data.AcceptInvite(userId, invitedUsername);
        }

         [HttpPost("DeleteInvite/{userId}/{invitedUsername}")]
        public bool DeleteInvite (int userId, string? invitedUsername)
        {
            return _data.DeleteInvite(userId, invitedUsername);
        }

        [HttpGet("AllInvitesByID/{userID}")]

        public IEnumerable<InviteUsersModel> AllInvitesByID (int userId)
        {
            return _data.AllInvitesByID(userId);
        }

        [HttpGet("AllInvitesByInvitedUsername/{username}")]
         public IEnumerable<InviteUsersModel> AllInvitesByInvitedUsername (string? username)
        {
            return _data.AllInvitesByInvitedUsername(username);
        }

         [HttpGet("GetAllUserInfoInviteRequests/{username}")]
        public IEnumerable<UserDTO> GetAllUserInfoInviteRequests(string? username)
        {
            return _data.GetAllUserInfoInviteRequests(username);
        }

    }
}