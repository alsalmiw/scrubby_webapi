using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using scrubby_webapi.Models;
using scrubby_webapi.Models.DTO;
using scrubby_webapi.Services.Context;
using System.Text;

namespace scrubby_webapi.Services
{
    public class UserService: ControllerBase
    {
        private readonly DataContext _context;
        public UserService(DataContext context)
        {
            _context = context;
        }

        public bool DoesUserExists(string? username)
        {
            return _context.UserInfo.SingleOrDefault(user => user.Username == username) != null;
        }

         public UserModel GetUserByUserName(string? username)
        {
            return _context.UserInfo.SingleOrDefault(user => user.Username == username);
        }

        public UserModel GetUserByID(int ID)
        {
            return _context.UserInfo.SingleOrDefault(user => user.Id == ID);
        }
         public PasswordDTO HashPassword(string? password)
        {
            PasswordDTO newHashedPassword = new PasswordDTO();
            byte[] SaltBytes = new byte[64];
            var provider = RandomNumberGenerator.Create();
            provider.GetNonZeroBytes(SaltBytes);
            var Salt = Convert.ToBase64String(SaltBytes);
            var rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, SaltBytes, 10000);
            var HashPassword = Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(256));
            newHashedPassword.Salt = Salt;
            newHashedPassword.Hash = HashPassword;
            return newHashedPassword;

        }

        public bool VerifyUserPassword(string? Password, string? StoredHash, string? StoredSalt)
        {
            var SaltBytes = Convert.FromBase64String(StoredSalt);
            var rfc2898DeriveBytes = new Rfc2898DeriveBytes(Password, SaltBytes, 10000);
            var newHash = Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(256));
            return newHash == StoredHash;
        }



         public bool AddUser(CreateAccountDTO UserToAdd)
        {
             bool result = false;
            if (!DoesUserExists(UserToAdd.Username))
            {
                UserModel newUser = new UserModel();
								newUser.Id = UserToAdd.Id; 
                newUser.Username = UserToAdd.Username;
                
                var hashedPassword = HashPassword(UserToAdd.Password);
             
                newUser.Salt = hashedPassword.Salt;
                newUser.Hash = hashedPassword.Hash;
							
                _context.Add(newUser);

                result = _context.SaveChanges() != 0;   
            }
            return result;
        }

        public IActionResult Login([FromBody] LoginDTO user){
            
               IActionResult Result = Unauthorized();
            if (DoesUserExists(user.Username))
            {
                //true
                var foundUser = GetUserByUserName(user.Username);
                //check to see if passeword is correct
                var result = VerifyUserPassword(user.Password, foundUser.Hash, foundUser.Salt);
                if (result)
                {
                    var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("BlogPostSuperKey@209"));
                    var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                    var tokeOptions = new JwtSecurityToken(
                        issuer: "http://localhost:5000",
                        audience: "http://localhost:5000",
                        claims: new List<Claim>(),
                        expires: DateTime.Now.AddMinutes(30),
                        signingCredentials: signinCredentials
                    );
                    var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                    Result = Ok(new { Token = tokenString });
                }
            }
            return Result;
        }

        public bool UpdateUsername(int id, string Username)
        {
             UserModel foundUser = GetUserByID(id);
            bool result = false;
            if(foundUser != null)
            {
                //A user was foundUser
                foundUser.Username = Username;
                _context.Update<UserModel>(foundUser);
               result =  _context.SaveChanges() != 0;
            }
            return result;
        }

  
        



    }
}