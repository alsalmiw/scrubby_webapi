using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using scrubby_webapi.Models.DTO;
using scrubby_webapi.Services;

namespace scrubby_webapi.Models
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserService _data;

        public UserController(UserService _dataFromService)
        {
            _data = _dataFromService;
        }

        [HttpPost("AddUser")]
        public bool AddUser(CreateAccountDTO UserToAdd)
        {
            return _data.AddUser(UserToAdd);
        }
        [HttpPost("Login")]
        public IActionResult Login([FromBody] LoginDTO User){
            return _data.Login(User);
        }
   
        [HttpPost("UpdateUser/{id}/{username}")]

        public bool UpdateUsername(int id, string username)
        {
            return _data.UpdateUsername(id, username);
        }

        [HttpPost("UpdateUserInfo/{id}")]

        public bool DeleteUser(int id)
        {
            return _data.DeleteUser(id);
        }
        [HttpGet("GetAllUsers")]
        public IEnumerable<UserModel> GetAllUsers()
        {
            return _data.GetAllUsers();
        }

        [HttpGet("GetUserPublicInfoByUserName/{username}")]
        public UserDTO GetUserPublicInfoByUserName(string username)
        {
            return _data.GetUserPublicInfoByUserName(username);
        }

        [HttpPost("UpdateName")]
        public bool UpdateName(UserDTO newName)
        {
            return _data.UpdateName(newName);
        }

        [HttpPost("UpdatePassword")]
        public bool UpdatePassword(LoginDTO newPassword)
        {
            return _data.UpdatePassword(newPassword);
        }


    }
}