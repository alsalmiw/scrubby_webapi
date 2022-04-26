using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using scrubby_webapi.Services.Context;
using scrubby_webapi.Models;



namespace scrubby_webapi.Services
{
    public class InviteUsersService
    {
        private readonly DataContext _context;
        public InviteUsersService(DataContext context)
        {
            _context = context; 
        }

         public UserModel GetUserByUserName(string? username)
        {
            return _context.UserInfo.SingleOrDefault(user => user.Username == username);
        }
        public bool InviteUser (InviteUsersModel newUser)
        {
            bool result = false;
            UserModel foundUser = GetUserByUserName(newUser.InvitedUsername);
            if(foundUser != null)
            {
            _context.Add(newUser);
            result= _context.SaveChanges() !=0;
            }
            return result ;
        }

       
        public bool AcceptInvite (int userId, string? invitedUsername)
        {
            bool result = false;
           InviteUsersModel foundInvite = FindInvite(userId,invitedUsername);
            if(foundInvite != null)
            {
                foundInvite.IsAccepted=true;
                     _context.Update<InviteUsersModel>(foundInvite);
                        result =  _context.SaveChanges() != 0;
            }
            return result;
        }

        public InviteUsersModel FindInvite (int userId, string? invitedUsername)
        {
            return  _context.InvitesInfo.SingleOrDefault(invite => invite.UserId == userId && invite.InvitedUsername == invitedUsername && invite.IsDeleted==false && invite.IsAccepted==false);
        }

        public bool DeleteInvite (int userId, string? invitedUsername)
        {
            bool result = false;
           InviteUsersModel foundInvite = FindInvite(userId,invitedUsername);
            if(foundInvite != null)
            {
                foundInvite.IsDeleted=true;
                     _context.Update<InviteUsersModel>(foundInvite);
                        result =  _context.SaveChanges() != 0;
            }
            return result;
        }

        public IEnumerable<InviteUsersModel> AllInvitesByID (int userId)
        {
          return _context.InvitesInfo.Where(user => user.UserId == userId);
        }

         public IEnumerable<InviteUsersModel> AllInvitesByInvitedUsername (string? username)
        {
          return _context.InvitesInfo.Where(user => user.InvitedUsername == username);
            
        }
    }
}