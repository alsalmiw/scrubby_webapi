using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using scrubby_webapi.Services.Context;
using scrubby_webapi.Models;
using scrubby_webapi.Models.DTO;




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

        public UserModel GetUserByID(int ID)
        {
            return _context.UserInfo.SingleOrDefault(user => user.Id == ID);
        }

        public bool InviteUser(InviteDTO newUser)
        {
            bool result = false;
            UserModel findInvited = GetUserByUserName(newUser.InvitedUsername);
            if (findInvited != null)
            {
                InviteUsersModel foundInvite = _context.InvitesInfo.SingleOrDefault(invite => invite.InvitedUsername == newUser.InvitedUsername && invite.InviterId == newUser.InviterId && invite.IsDeleted == false);

                if (foundInvite != null)
                {
                    result = false;
                }
                else
                {
                    InviteUsersModel newInvite = new InviteUsersModel();
                    UserModel findInviter = GetUserByID(newUser.InviterId);

                    if (findInviter != null)
                    {
                        newInvite.Id = 0;
                        newInvite.InviterId = findInviter.Id;
                        newInvite.InviterUsername = findInviter.Username;
                        newInvite.InviterFullname = findInviter.Name;
                        newInvite.InviterPhoto = findInviter.Photo;
                        newInvite.InvitedId = findInvited.Id;
                        newInvite.InvitedUsername = findInvited.Username;
                        newInvite.InvitedFullname = findInvited.Name;
                        newInvite.InvitedPhoto = findInvited.Photo;
                        newInvite.IsAccepted = false;
                        newInvite.IsDeleted = false;

                        _context.Add(newInvite);
                        result = _context.SaveChanges() != 0;
                    }


                }

            }
            return result;
        }


        public bool AcceptInvite(int userId, string? invitedUsername)
        {
            bool result = false;
            InviteUsersModel foundInvite = FindInvite(userId, invitedUsername);
            if (foundInvite != null)
            {
                foundInvite.IsAccepted = true;
                _context.Update<InviteUsersModel>(foundInvite);
                result = _context.SaveChanges() != 0;
            }
            return result;
        }

        public InviteUsersModel FindInvite(int userId, string? invitedUsername)
        {
            return _context.InvitesInfo.SingleOrDefault(invite => invite.InviterId == userId && invite.InvitedUsername == invitedUsername && invite.IsDeleted == false && invite.IsAccepted == false);
        }

        public bool DeleteInvite(int userId, string? invitedUsername)
        {
            bool result = false;
            InviteUsersModel foundInvite = FindInvite(userId, invitedUsername);
            if (foundInvite != null)
            {
                foundInvite.IsDeleted = true;
                _context.Update<InviteUsersModel>(foundInvite);
                result = _context.SaveChanges() != 0;
            }
            return result;
        }

        public IEnumerable<InviteUsersModel> AllInvitesByID(int userId)
        {
            return _context.InvitesInfo.Where(user => user.InviterId == userId);
        }

        public IEnumerable<InviteUsersModel> AllInvitesByInvitedUsername(string? username)
        {
            return _context.InvitesInfo.Where(user => user.InvitedUsername == username);
        }

        public IEnumerable<UserDTO> GetAllUserInfoInviteRequests(string? username)
        {
            List<UserDTO> Invitees = new List<UserDTO>();

            List<InviteUsersModel> findInvites = _context.InvitesInfo.Where(user => user.InvitedUsername == username).ToList();
            List<UserModel> findUsers = new List<UserModel>();

            if (findInvites != null)
            {
                for (int i = 0; i < findInvites.Count; i++)
                {
                    UserModel userInList = new UserModel();
                    userInList = _context.UserInfo.SingleOrDefault(user => user.Id == findInvites[i].InviterId);
                    findUsers.Add(userInList);
                };

                if (findUsers != null)
                {
                    for (int j = 0; j < findUsers.Count; j++)
                    {
                        UserDTO user = new UserDTO();
                        user.Id = findUsers[j].Id;
                        user.Name = findUsers[j].Name;
                        user.Username = findUsers[j].Username;
                        user.Photo = findUsers[j].Photo;
                        user.Points = findUsers[j].Points;
                        user.Coins = findUsers[j].Coins;
                        user.IsDeleted = findUsers[j].IsDeleted;

                        Invitees.Add(user);
                    }
                }
            }

            return Invitees;
        }
    }
}