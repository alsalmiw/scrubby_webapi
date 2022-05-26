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
        public bool InviteUser(InviteDTO newUser)
        {
            return _data.InviteUser(newUser);
        }

        [HttpPost("AcceptInvite/{userId}/{invitedUsername}")]
        public bool AcceptInvite(int userId, string? invitedUsername)
        {
            return _data.AcceptInvite(userId, invitedUsername);
        }

        [HttpPost("DeleteInvite/{userId}/{invitedUsername}")]
        public bool DeleteInvite(int userId, string? invitedUsername)
        {
            return _data.DeleteInvite(userId, invitedUsername);
        }

        [HttpPost("DeleteInvitation/{inviteId}")]
        public bool DeleteInvitation(int inviteId)
        {
            return _data.DeleteInvitation(inviteId);
        }


        [HttpGet("AllInvitesByID/{userID}")]

        public IEnumerable<InviteUsersModel> AllInvitesByID(int userId)
        {
            return _data.AllInvitesByID(userId);
        }

        [HttpGet("AllInvitesByInvitedUsername/{username}")]
        public IEnumerable<InviteUsersModel> AllInvitesByInvitedUsername(string? username)
        {
            return _data.AllInvitesByInvitedUsername(username);
        }

        [HttpGet("GetAllUserInfoInviteRequests/{username}")]
        public IEnumerable<UserDTO> GetAllUserInfoInviteRequests(string? username)
        {
            return _data.GetAllUserInfoInviteRequests(username);
        }

        [HttpGet("GetInvitationsByUsername/{username}")]
        public InvitesDTO GetInvitationsByUsername(string? username)
        {
            return _data.GetInvitationsByUsername(username);
        }

        [HttpPost("DeleteAcceptedInvite/{userId}/{invitedUsername}")]
        public bool DeleteAcceptedInvite(int userId, string? invitedUsername)
        {
            return _data.DeleteAcceptedInvite(userId, invitedUsername);
        }

        [HttpPost("DeleteInvitation/{invitedUsername}/{inviterUsername}")]
        public bool DeleteInvitation (string? invitedUsername, string? inviterUsername)
        {
            return _data.DeleteInvitation(invitedUsername, inviterUsername);
        }



    }
}