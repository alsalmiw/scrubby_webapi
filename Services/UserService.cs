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
using scrubby_webapi.Models.Static;
using scrubby_webapi.Models.DTO;
using scrubby_webapi.Services.Context;
using System.Text;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.Serialization.Formatters;

namespace scrubby_webapi.Services
{
    public class UserService : ControllerBase
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

        public UserDTO GetPublicUserInfoByID(int ID)
        {
            UserDTO userInfo = new UserDTO();
            UserModel foundUser = GetUserByID(ID);
            if (foundUser != null)
            {
                //A user was foundUser
                userInfo.Id = foundUser.Id;
                userInfo.Name = foundUser.Name;
                userInfo.Username = foundUser.Username;
                userInfo.Photo = foundUser.Photo;
                userInfo.Points = foundUser.Points;
                userInfo.Coins = foundUser.Coins;
                userInfo.IsDeleted = foundUser.IsDeleted;

            }
            return userInfo;
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

        public IActionResult Login([FromBody] LoginDTO user)
        {

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
            if (foundUser != null)
            {
                //A user was foundUser
                foundUser.Username = Username;
                _context.Update<UserModel>(foundUser);
                result = _context.SaveChanges() != 0;
            }
            return result;
        }

        public bool DeleteUser(int id)
        {
            UserModel foundUser = GetUserByID(id);
            bool result = false;
            if (foundUser != null)
            {
                //A user was foundUser
                foundUser.IsDeleted = true;
                _context.Update<UserModel>(foundUser);
                result = _context.SaveChanges() != 0;
            }
            return result;
        }
        public IEnumerable<UserModel> GetAllUsers()
        {
            return _context.UserInfo;
        }


        public bool UpdateName(UserDTO newName)
        {
            UserModel foundUser = GetUserByUserName(newName.Username);
            bool result = false;
            if (foundUser != null)
            {
                //A user was foundUser
                foundUser.Name = newName.Name;
                _context.Update<UserModel>(foundUser);
                result = _context.SaveChanges() != 0;
            }
            return result;
        }

        public UserDTO GetUserPublicInfoByUserName(string username)
        {
            UserDTO userInfo = new UserDTO();
            UserModel foundUser = GetUserByUserName(username);
            if (foundUser != null)
            {
                //A user was foundUser
                userInfo.Id = foundUser.Id;
                userInfo.Name = foundUser.Name;
                userInfo.Username = foundUser.Username;
                userInfo.Photo = foundUser.Photo;
                userInfo.Points = foundUser.Points;
                userInfo.Coins = foundUser.Coins;
                userInfo.IsDeleted = foundUser.IsDeleted;

            }
            return userInfo;
        }

        public UserDTO GetUserPublicInfoByID(int id)
        {
            UserDTO userInfo = new UserDTO();
            UserModel foundUser = GetUserByID(id);
            if (foundUser != null)
            {
                //A user was foundUser
                userInfo.Id = foundUser.Id;
                userInfo.Name = foundUser.Name;
                userInfo.Username = foundUser.Username;
                userInfo.Photo = foundUser.Photo;
                userInfo.Points = foundUser.Points;
                userInfo.Coins = foundUser.Coins;
                userInfo.IsDeleted = foundUser.IsDeleted;

            }
            return userInfo;
        }

        public bool UpdatePassword(LoginDTO newPassword)
        {
            bool result = false;
            UserModel foundUser = GetUserByUserName(newPassword.Username);
            if (foundUser != null)
            {
                var hashedPassword = HashPassword(newPassword.Password);
                foundUser.Hash = hashedPassword.Hash;
                foundUser.Salt = hashedPassword.Salt;
                _context.Update<UserModel>(foundUser);
                result = _context.SaveChanges() != 0;
            }

            return result;
        }



        public bool ChildFreeBool(int userId)
        {
            UserModel foundUser = GetUserByID(userId);
            bool result = false;
            if (foundUser != null)
            {
                //A user was foundUser
                foundUser.IsChildFree = !foundUser.IsChildFree;
                _context.Update<UserModel>(foundUser);
                result = _context.SaveChanges() != 0;
            }
            return result;

        }

        public bool AddDefaultAvatar(UserImageDTO avatar)
        {
            UserModel foundUser = GetUserByUserName(avatar.Username);
            bool result = false;
            if (foundUser != null)
            {

                foundUser.Photo = avatar.Photo;
                _context.Update<UserModel>(foundUser);
                result = _context.SaveChanges() != 0;
            }

            return result;
        }

        public UserDataDTO GetUserData(string? username)
        {
            UserDataDTO userData = new UserDataDTO();
            UserDTO UserInfo = GetUserPublicInfoByUserName(username);
            if (UserInfo != null)
            {
                userData.userInfo = UserInfo;

                List<DependentModel> UsersKids = UserKids(UserInfo.Id);
                if (UsersKids != null)
                {
                    userData.Children = UsersKids;
                }

                List<CollectionsDTO> spaceCollections = GetCollectionByUserId(UserInfo.Id);
                if (spaceCollections != null)
                {
                    userData.Spaces = spaceCollections;
                }

                InvitesDTO getUserInvites = GetInvitationInfoByUserId(UserInfo.Id);
                if (getUserInvites != null)
                {
                    userData.Invitations = getUserInvites;
                }
            }
            List<ScoreBoardPointsDTO> ScoreBoardInfo = ScoreBoardList(username);
            if (ScoreBoardInfo != null)
            {
                userData.ScoreBoard = ScoreBoardInfo;
            }

            return userData;
        }

        public List<DependentModel> UserKids(int id)
        {
            return _context.DependentInfo.Where(child => child.UserId == id && child.IsDeleted == false).ToList();
        }

        public List<CollectionsDTO> GetCollectionByUserId(int UserId)
        {
            List<CollectionsDTO> SpaceCollectionsDTO = new List<CollectionsDTO>();
            List<SpaceCollectionModel> collections = new List<SpaceCollectionModel>();
            collections = _context.SpaceCollectionInfo.Where(item => item.UserId == UserId).ToList();

            if (collections != null)
            {
                for (int i = 0; i < collections.Count; i++)
                {
                    CollectionsDTO oneCollection = new CollectionsDTO();
                    oneCollection.Id = collections[i].Id;
                    oneCollection.CollectionName = collections[i].CollectionName;
                    oneCollection.IsDeleted = collections[i].IsDeleted;
                    oneCollection.Rooms = GetRoomsByCollectionID(collections[i].Id);
                    oneCollection.SharedWith = GetSharedCollectionWithByCollectionId(collections[i].Id);

                    SpaceCollectionsDTO.Add(oneCollection);
                }
            }

            return SpaceCollectionsDTO;
        }

        public List<SpacesDTO> GetRoomsByCollectionID(int id)
        {
            List<SpacesDTO> spaceByCollectionIdDTO = new List<SpacesDTO>();
            List<SpaceInfoModel> spaces = _context.SpaceInfo.Where(space => space.CollectionId == id).ToList();

            if (spaces != null)
            {
                for (int i = 0; i < spaces.Count; i++)
                {
                    SpacesDTO oneSpace = new SpacesDTO();
                    oneSpace.Id = spaces[i].Id;
                    oneSpace.SpaceName = spaces[i].SpaceName;
                    oneSpace.SpaceCategory = spaces[i].SpaceCategory;
                    oneSpace.Tasks = GetTasksBySpaceId(spaces[i].Id);
                    oneSpace.TasksAssigned = GetAllAssignedTasksBySpaceId(spaces[i].Id);

                    spaceByCollectionIdDTO.Add(oneSpace);
                }
            }

            return spaceByCollectionIdDTO;
        }

        // public List<AssignedUsersDTO> GetAssignedUsersBySpaceId(int id)
        // {
        //         List<AssignedUsersDTO> Assingments = new List<AssignedUsersDTO>();
        //         List<AssignedTasksUsersModel> AssignedUsers = _context.AssignedTasksUsersInfo.Where(assignment => assignment.SpaceId == id).ToList();
        //         if(AssignedUsers.Count!= 0)
        //         {

        //             for(int i = 0; i < AssignedUsers.Count; i++){
        //             AssignedUsersDTO oneAssigned = new AssignedUsersDTO();
        //             UserModel findUser = _context.UserInfo.SingleOrDefault(user => user.Id == AssignedUsers[i].UserId);
        //             oneAssigned.Id=AssignedUsers[i].Id;
        //             oneAssigned.Name = findUser.Name;
        //             oneAssigned.IsChild=false;
        //             oneAssigned.AssignedTasks = GetAllAssignedTasksByUserId(AssignedUsers[i].Id);
        //             Assingments.Add(oneAssigned);
        //             }
        //         }
                

        //         List<AssignedTasksChildModel> AssignedChildren = _context.AssignedTasksChildInfo.Where(assignment => assignment.SpaceId == id).ToList();
        //         if(AssignedChildren.Count!=0)
        //         {
        //              for(int i = 0; i < AssignedUsers.Count; i++){
        //             AssignedUsersDTO oneAssigned = new AssignedUsersDTO();
        //             DependentModel findChild = _context.DependentInfo.SingleOrDefault(child => child.Id == AssignedUsers[i].Id);
        //             oneAssigned.Id=AssignedUsers[i].Id;
        //             oneAssigned.Name = findChild.DependentName;
        //             oneAssigned.IsChild=true;
        //             oneAssigned.AssignedTasks = GetAllAssignedTasksByChildId(AssignedUsers[i].Id);
        //             Assingments.Add(oneAssigned);
        //         }
        //         }
                
               
            
        //     return Assingments;
        // }

        public List<AssignedTasksDTO>GetAllAssignedTasksBySpaceId(int id){
            
            List<AssignedTasksDTO> AssignedTasks = new List<AssignedTasksDTO>();
            List<AssignedTasksDTO> AssignedUsers = GetAllAssignedUserTasksBySpaceId(id);
            List<AssignedTasksDTO> AssignedChildren = GetAllAssignedChildTasksBySpaceId(id);

             if(AssignedUsers.Count!=0)
             {
                    for(int i = 0; i < AssignedUsers.Count; i++)
                    {
                        AssignedTasks.Add(AssignedUsers[i]);
                    }
             }

             if(AssignedChildren.Count!=0)
             {
                     for(int i = 0; i < AssignedChildren.Count; i++)
                    {
                        AssignedTasks.Add(AssignedChildren[i]);
                    }

             }
           
           return AssignedTasks;

        }

         public List<AssignedTasksDTO>GetAllAssignedUserTasksBySpaceId(int id){

            List<AssignedTasksUsersModel> AssignedUsers = _context.AssignedTasksUsersInfo.Where(assignment => assignment.SpaceId == id && assignment.IsDeleted==false).ToList();

              List<AssignedTasksDTO> AssignedTasks = new List<AssignedTasksDTO>();


                if(AssignedUsers.Count!=0)
                {
                     for(int i = 0; i < AssignedUsers.Count; i++)
                    {
                    UserModel findUser = _context.UserInfo.SingleOrDefault(user => user.Id == AssignedUsers[i].UserId);

                    AssignedTasksDTO oneTask = new AssignedTasksDTO();
                    oneTask.Id = AssignedUsers[i].Id;
                    oneTask.UserId = AssignedUsers[i].UserId;
                    oneTask.Name = findUser.Name;
                    oneTask.AssignedTaskId= AssignedUsers[i].AssignedTaskId;
                    oneTask.DateScheduled = AssignedUsers[i].DateCreated;
                    oneTask.DateCompleted= AssignedUsers[i].DateCompleted;
                    oneTask.IsCompleted = AssignedUsers[i].IsCompleted;
                    oneTask.IsChild=false;
                    AssignedTasks.Add(oneTask);
                    }
                }
               
            return AssignedTasks;
                
                
        }


         public List<AssignedTasksDTO>GetAllAssignedChildTasksBySpaceId(int id){

            List<AssignedTasksChildModel> AssignedChildren = _context.AssignedTasksChildInfo.Where(assignment => assignment.SpaceId == id && assignment.IsDeleted==false).ToList();
            
            List<AssignedTasksDTO> AssignedTasks = new List<AssignedTasksDTO>();
            
                if(AssignedChildren.Count!=0)
                {
                     for(int i = 0; i < AssignedChildren.Count; i++)
                    {
                     DependentModel findChild = _context.DependentInfo.SingleOrDefault(child => child.Id == AssignedChildren[i].Id);

                    AssignedTasksDTO oneTask = new AssignedTasksDTO();
                    oneTask.Id = AssignedChildren[i].Id;
                    oneTask.UserId = AssignedChildren[i].ChildId;
                    oneTask.Name = findChild.DependentName;
                    oneTask.AssignedTaskId= AssignedChildren[i].AssignedTaskId;
                    oneTask.DateScheduled = AssignedChildren[i].DateCreated;
                    oneTask.DateCompleted= AssignedChildren[i].DateCompleted;
                    oneTask.IsCompleted = AssignedChildren[i].IsCompleted;
                    oneTask.IsChild=true;
                    AssignedTasks.Add(oneTask);
                    }
                }
               
            return AssignedTasks;
        }



        public List<AssignedTasksDTO>GetAllAssignedTasksByUserId(int id){
                List<AssignedTasksUsersModel> AssignedUsers = _context.AssignedTasksUsersInfo.Where(assignment => assignment.UserId == id && assignment.IsDeleted==false).ToList();
                List<AssignedTasksDTO> AssignedTasks = new List<AssignedTasksDTO>();


                if(AssignedUsers.Count!=0)
                {
                     for(int i = 0; i < AssignedUsers.Count; i++)
                    {
                    AssignedTasksDTO oneTask = new AssignedTasksDTO();
                    oneTask.Id = AssignedUsers[i].Id;
                    oneTask.UserId = AssignedUsers[i].Id;
                    oneTask.AssignedTaskId= AssignedUsers[i].AssignedTaskId;
                    oneTask.DateScheduled = AssignedUsers[i].DateCreated;
                    oneTask.DateCompleted= AssignedUsers[i].DateCompleted;
                    oneTask.IsCompleted = AssignedUsers[i].IsCompleted;
                    AssignedTasks.Add(oneTask);
                    }
                }
               
            return AssignedTasks;
        }

         public List<AssignedTasksDTO>GetAllAssignedTasksByChildId(int id){
                List<AssignedTasksChildModel> AssignedChildren = _context.AssignedTasksChildInfo.Where(assignment => assignment.ChildId == id && assignment.IsDeleted==false).ToList();
                List<AssignedTasksDTO> AssignedTasks = new List<AssignedTasksDTO>();

                if(AssignedChildren.Count!=0)
                {
                     for(int i = 0; i < AssignedChildren.Count; i++)
                    {
                    AssignedTasksDTO oneTask = new AssignedTasksDTO();
                    oneTask.Id = AssignedChildren[i].Id;
                    oneTask.UserId = AssignedChildren[i].Id;
                    oneTask.AssignedTaskId= AssignedChildren[i].AssignedTaskId;
                    oneTask.DateScheduled = AssignedChildren[i].DateCreated;
                    oneTask.DateCompleted= AssignedChildren[i].DateCompleted;
                    oneTask.IsCompleted = AssignedChildren[i].IsCompleted;
                    AssignedTasks.Add(oneTask);
                    }
                }
                
            return AssignedTasks;
        }


        public List<SharedSpacesDTO> GetSharedCollectionWithByCollectionId(int id)
        {

            List<SharedSpacesDTO> sharedSpacesDTO = new List<SharedSpacesDTO>();

            List<SharedSpacesModel> sharedCollection = _context.SharedSpacesInfo.Where(collection => collection.CollectionId == id && (collection.IsDeleted == false && collection.IsAccepted == true)).ToList();

            for (int i = 0; i < sharedCollection.Count; i++)
            {
                SharedSpacesDTO sharedSpaceWith = new SharedSpacesDTO();
                sharedSpaceWith.Id = sharedCollection[i].Id;
                UserModel findInvited = GetUserByUserName(sharedCollection[i].InvitedUsername);
                sharedSpaceWith.InvitedId = findInvited.Id;
                sharedSpaceWith.InvitedUsername = findInvited.Username;
                sharedSpaceWith.InvitedName = findInvited.Name;

                sharedSpacesDTO.Add(sharedSpaceWith);
            }

            return sharedSpacesDTO;

        }

        public List<SelectedTasksDTO> GetTasksBySpaceId(int id)
        {
            List<SelectedTasksDTO> spaceTasksDTO = new List<SelectedTasksDTO>();
            List<SelectedTasksModel> tasks = _context.SelectedTasksInfo.Where(task => task.SpaceId == id).ToList();

            if (tasks != null)
            {
                for (int i = 0; i < tasks.Count; i++)
                {
                    SelectedTasksDTO oneTask = new SelectedTasksDTO();
                    oneTask.Id = tasks[i].Id;
                    oneTask.DateCompleted = tasks[i].DateCompleted;
                    oneTask.DateCompleted = tasks[i].DateCompleted;
                    oneTask.IsDeleted = tasks[i].IsDeleted;
                    oneTask.IsArchived = tasks[i].IsArchived;
                    oneTask.Task = GetTaskByTaskID(tasks[i].TaskId);
                    oneTask.Item = _context.SpaceItemsStaticAPIInfo.SingleOrDefault(item => item.Id == tasks[i].ItemId);


                    spaceTasksDTO.Add(oneTask);

                }
            }
            return spaceTasksDTO;
        }

        public TasksInfoStaticAPIModel GetTaskByTaskID(int id)
        {
            return _context.TasksInfoStaticAPIInfo.SingleOrDefault(task => task.Id == id);
        }

        public InvitesDTO GetInvitationInfoByUserId(int id)
        {

            List<SentInvitesDTO> SentInvites = new List<SentInvitesDTO>();
            List<RecievedInvitesDTO> RecievedInvites = new List<RecievedInvitesDTO>();
            InvitesDTO userInvites = new InvitesDTO();

            List<InviteUsersModel> allInvitesForUser = _context.InvitesInfo.Where(invite => (invite.InviterId == id || invite.InvitedId == id) && invite.IsDeleted != true).ToList();

            if (allInvitesForUser != null)
            {
                for (int i = 0; i < allInvitesForUser.Count; i++)
                {
                    if (allInvitesForUser[i].InviterId == id)
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



                    if (allInvitesForUser[i].InvitedId == id)
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

        public List<ScoreBoardPointsDTO> ScoreBoardList(string? username)
        {

            List<ScoreBoardPointsDTO> ScoresInfo = new List<ScoreBoardPointsDTO>();
            ScoreBoardPointsDTO usersScoreInfo = new ScoreBoardPointsDTO();

            UserModel foundUser = GetUserByUserName(username);
            if (foundUser != null)
            {
                usersScoreInfo.Name = foundUser.Name;
                usersScoreInfo.Points = foundUser.Points;
                ScoresInfo.Add(usersScoreInfo);

                List<DependentModel> UsersKids = UserKids(foundUser.Id);
                if (UsersKids != null)
                {
                    for (int i = 0; i < UsersKids.Count; i++)
                    {
                        ScoreBoardPointsDTO kidScore = new ScoreBoardPointsDTO();
                        kidScore.Name = UsersKids[i].DependentName;
                        kidScore.Points = UsersKids[i].DependentPoints;
                        ScoresInfo.Add(kidScore);
                    }
                }

                List<InviteUsersModel> allInvitesForUser = _context.InvitesInfo.Where(user => user.InviterId == foundUser.Id && user.IsDeleted == false && user.IsAccepted == true).ToList();

                List<UserModel> invitedUsersInfo = new List<UserModel>();

                if (allInvitesForUser != null)
                {
                    for (int k = 0; k < allInvitesForUser.Count; k++)
                    {
                        UserModel invited = _context.UserInfo.FirstOrDefault(user => user.Id == allInvitesForUser[k].InvitedId);
                        invitedUsersInfo.Add(invited);
                    }

                }

                if (invitedUsersInfo != null)
                {
                    for (int j = 0; j < invitedUsersInfo.Count; j++)
                    {
                        ScoreBoardPointsDTO invitedScore = new ScoreBoardPointsDTO();
                        invitedScore.Name = invitedUsersInfo[j].Name;
                        invitedScore.Points = invitedUsersInfo[j].Points;
                        ScoresInfo.Add(invitedScore);

                    }
                }


            }


            return ScoresInfo;



        }

        public UserDTO NewCoinAmount(UserDTO newAmount)
        {
            UserDTO userInfo = new UserDTO();
            UserModel foundUser = GetUserByID(newAmount.Id);
            bool result = false;
            if (foundUser != null)
            {
                //A user was foundUser
                foundUser.Coins = newAmount.Coins;
                _context.Update<UserModel>(foundUser);
                result = _context.SaveChanges() != 0;

                if (result)
                {
                    userInfo = GetUserPublicInfoByID(foundUser.Id);
                }
            }
            return userInfo;
        }

    }
}