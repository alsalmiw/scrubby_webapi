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


        public InviteUsersModel FindAcceptedInvite(int userId, string? invitedUsername)
        {
            return _context.InvitesInfo.SingleOrDefault(invite => invite.InviterId == userId && invite.InvitedUsername == invitedUsername && invite.IsDeleted == false && invite.IsAccepted == true);
        }

        public bool DeleteAcceptedInvite(int userId, string? invitedUsername)
        {
            bool result = false;
            InviteUsersModel foundInvite = FindAcceptedInvite(userId, invitedUsername);
            if (foundInvite != null)
            {
                foundInvite.IsDeleted = true;
                _context.Update<InviteUsersModel>(foundInvite);
                result = _context.SaveChanges() != 0;
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

        public InviteUsersModel FindInviteByInviteId(int id)
        {
            return _context.InvitesInfo.SingleOrDefault(invite => invite.Id == id);
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

        public bool DeleteInvitation(int inviteId)
        {
            bool result = false;
            InviteUsersModel foundInvite = FindInviteByInviteId(inviteId);
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

        public InvitesDTO GetInvitationsByUsername(string? username)
        {
            List<SentInvitesDTO> SentInvites = new List<SentInvitesDTO>();
            List<RecievedInvitesDTO> RecievedInvites = new List<RecievedInvitesDTO>();
            InvitesDTO userInvites = new InvitesDTO();

            List<InviteUsersModel> allInvitesForUser = _context.InvitesInfo.Where(invite => (invite.InviterUsername == username || invite.InvitedUsername == username) && invite.IsDeleted != true).ToList();

            if (allInvitesForUser != null)
            {
                for (int i = 0; i < allInvitesForUser.Count; i++)
                {
                    if (allInvitesForUser[i].InviterUsername == username)
                    {
                        SentInvitesDTO sentInvite = new SentInvitesDTO();
                        sentInvite.Id = allInvitesForUser[i].Id;
                        sentInvite.InvitedId = allInvitesForUser[i].InvitedId;
                        sentInvite.InvitedUsername = allInvitesForUser[i].InvitedUsername;
                        sentInvite.InvitedFullname = allInvitesForUser[i].InvitedFullname;
                        sentInvite.InvitedPhoto = allInvitesForUser[i].InvitedPhoto;
                        sentInvite.IsAccepted = allInvitesForUser[i].IsAccepted;
                        sentInvite.IsDeleted = allInvitesForUser[i].IsDeleted;

                        SentInvites.Add(sentInvite);
                    }



                    if (allInvitesForUser[i].InvitedUsername == username)
                    {
                        RecievedInvitesDTO recievedInvite = new RecievedInvitesDTO();
                        recievedInvite.Id = allInvitesForUser[i].Id;
                        recievedInvite.InviterId = allInvitesForUser[i].InviterId;
                        recievedInvite.InviterUsername = allInvitesForUser[i].InviterUsername;
                        recievedInvite.InviterFullname = allInvitesForUser[i].InviterFullname;
                        recievedInvite.InviterPhoto = allInvitesForUser[i].InviterPhoto;
                        recievedInvite.IsAccepted = allInvitesForUser[i].IsAccepted;
                        recievedInvite.IsDeleted = allInvitesForUser[i].IsDeleted;

                        RecievedInvites.Add(recievedInvite);
                    }
                }
            }
            userInvites.SentInvites = SentInvites;
            userInvites.RecievedInvites = RecievedInvites;

            return userInvites;
        }

         public bool DeleteInvitation (string? invitedUsername, string? inviterUsername)
        {
            bool result = false;
            List <InviteUsersModel> findInvite = _context.InvitesInfo.Where(invite => invite.InvitedUsername == invitedUsername && invite.InviterUsername == inviterUsername && invite.IsDeleted == false).ToList();
            if(findInvite != null)
            {
                for(int i = 0; i < findInvite.Count; i++)
                {
                    findInvite[i].IsDeleted = true;
                    _context.Update<InviteUsersModel>(findInvite[i]);
                    _context.SaveChanges();
                }
      
                List<SharedSpacesModel> findShared = _context.SharedSpacesInfo.Where(shared => shared.InvitedUsername == invitedUsername && shared.InviterUsername==inviterUsername && shared.IsDeleted == false).ToList();
                if(findShared != null)
                {
                    for(int j = 0; j < findShared.Count; j++)
                    {
                        findShared[j].IsDeleted = true;
                         _context.Update<SharedSpacesModel>(findShared[j]);
                         result = _context.SaveChanges() != 0;

                    }
                }
            }
            return result;
        }
    }
}