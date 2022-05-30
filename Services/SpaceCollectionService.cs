using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using scrubby_webapi.Models;
using scrubby_webapi.Models.DTO;
using scrubby_webapi.Services.Context;

namespace scrubby_webapi.Services
{
    public class SpaceCollectionService
    {
        private readonly DataContext _context;
        private readonly SharedSpacesService _sharedSpaces;
        private readonly SpaceInfoService _spaceService;
        public SpaceCollectionService(DataContext context, SpaceInfoService spaceInfoService, SharedSpacesService sharedSpacesService)
        {
            _context = context;
            _spaceService = spaceInfoService;
            _sharedSpaces = sharedSpacesService;
        }
        public bool CreateSpaceCollection(SpaceCollectionModel SpaceCollectionToCreate)
        {
            _context.Add(SpaceCollectionToCreate);
            return _context.SaveChanges() != 0;
        }
        //edit or update
        public IEnumerable<SpaceCollectionModel> GetSpaceCollectionByUsername(string? username)
        {
            UserModel user = _context.UserInfo.SingleOrDefault(user => user.Username == username);

            List<SpaceCollectionModel> UsersCollections = _context.SpaceCollectionInfo.Where(collection => collection.UserId == user.Id && collection.IsDeleted == false).ToList();
            return UsersCollections;
        }

        public SpaceCollectionModel GetSpaceCollectionById(int Id)
        {
            return _context.SpaceCollectionInfo.SingleOrDefault(item => item.Id == Id);
        }

        public IEnumerable<SpaceCollectionModel> GetSpaceCollectionByUserId(int UserId)
        {
            return _context.SpaceCollectionInfo.Where(item => item.UserId == UserId && item.IsDeleted == false);
        }
        public bool DeleteSpaceCollectionById(int Id)
        {
            SpaceCollectionModel foundSpaceCollection = GetSpaceCollectionById(Id);
            bool result = false;
            bool isDeleted = false;
            if (foundSpaceCollection != null)
            {
                foundSpaceCollection.IsDeleted = true;
                _context.Update<SpaceCollectionModel>(foundSpaceCollection);
                isDeleted = _context.SaveChanges() != 0;
            }
            List<DefaultCollectionModel> findDefault = _context.DefaultCollectionInfo.Where(item => item.CollectionId == Id).ToList();
            if (isDeleted)
            {
                if (findDefault.Count > 0)
                {
                    for (int i = 0; i < findDefault.Count; i++)
                    {
                        findDefault[i].IsDeleted = true;
                        _context.Update<DefaultCollectionModel>(findDefault[i]);
                        result = _context.SaveChanges() != 0;
                    }
                }
                else
                {
                    result = true;
                }
            }

            return result;
        }

        //update space collection name
        public bool UpdateSpaceCollectionNameByUserId(int UserId, string CollectionName)
        {
            bool result = false;
            SpaceCollectionModel SpaceCollection = GetSpaceCollectionById(UserId);
            if (SpaceCollection != null)
            {
                SpaceCollection.CollectionName = CollectionName;
                _context.Update<SpaceCollectionModel>(SpaceCollection);
                result = _context.SaveChanges() != 0;
            }
            return result;
        }

        public List<CollectionsDTO> GetCollectionByUserId(int UserId)
        {
            List<CollectionsDTO> SpaceCollectionsDTO = new List<CollectionsDTO>();
            List<SpaceCollectionModel> collections = new List<SpaceCollectionModel>();
            collections = _context.SpaceCollectionInfo.Where(item => item.UserId == UserId && item.IsDeleted == false).ToList();

            if (collections != null)
            {
                for (int i = 0; i < collections.Count; i++)
                {
                    CollectionsDTO oneCollection = new CollectionsDTO();
                    oneCollection.Id = collections[i].Id;
                    oneCollection.CollectionName = collections[i].CollectionName;
                    oneCollection.IsDeleted = collections[i].IsDeleted;
                    oneCollection.Rooms = _spaceService.GetRoomsByCollectionID(collections[i].Id);
                    oneCollection.SharedWith = _sharedSpaces.GetSharedCollectionWithByCollectionId(collections[i].Id);

                    SpaceCollectionsDTO.Add(oneCollection);
                }
            }

            return SpaceCollectionsDTO;
        }

        public List<TasksHistoryDTO> GetAllTasksHistoryForMembersByUsername(string? username)
        {
            UserModel findUser = _context.UserInfo.SingleOrDefault(user => user.Username == username);
            return GetAllTasksHistoryForMembers(findUser.Id);
        }

        public List<TasksHistoryDTO> GetAllTasksHistoryForMembers(int userId)
        {
            //bool start = false;
            List<TasksHistoryDTO> AllTasksHistory = new List<TasksHistoryDTO>();
            // List<string> dates = new List<string>();
            // for (int d = 0; d < 50; d++)
            // {

            //     DateTime day = DateTime.Today.AddDays(-d);
            //     dates.Add(day.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ss.sss0Z"));
            //     if (d == 49)
            //     {
            //         start = true;
            //     }
            // }

            // if (start)
            // {



            List<CollectionsDTO> spaceCollections = GetCollectionByUserId(userId);


            if (spaceCollections != null)
            {

                for (int i = 0; i < spaceCollections.Count; i++)
                {
                    for (int j = 0; j < spaceCollections[i].Rooms.Count; j++)
                    {
                        for (int k = 0; k < spaceCollections[i].Rooms[j].TasksAssigned.Count; k++)
                        {
                            // if (dates.Contains(spaceCollections[i].Rooms[j].TasksAssigned[k].DateScheduled))
                            // {
                            TasksHistoryDTO OneTaskDetails = new TasksHistoryDTO();
                            OneTaskDetails.TaskSpace = spaceCollections[i].CollectionName;
                            OneTaskDetails.TaskRoom = spaceCollections[i].Rooms[j].SpaceName;
                            OneTaskDetails.MemberId = spaceCollections[i].Rooms[j].TasksAssigned[k].UserId;

                            OneTaskDetails.IsChild = spaceCollections[i].Rooms[j].TasksAssigned[k].IsChild;
                            OneTaskDetails.TaskId = spaceCollections[i].Rooms[j].TasksAssigned[k].AssignedTaskId;

                            OneTaskDetails.Name = spaceCollections[i].Rooms[j].TasksAssigned[k].Name;
                            OneTaskDetails.TaskName = GetTaskNameByTaskID(spaceCollections[i].Rooms[j].TasksAssigned[k].AssignedTaskId, spaceCollections[i].Rooms[j].Tasks);
                            OneTaskDetails.IsCompleted = spaceCollections[i].Rooms[j].TasksAssigned[k].IsCompleted;

                            OneTaskDetails.DateScheduled = spaceCollections[i].Rooms[j].TasksAssigned[k].DateScheduled;
                            OneTaskDetails.DateCompleted = spaceCollections[i].Rooms[j].TasksAssigned[k].DateCompleted;
                            if (spaceCollections[i].Rooms[j].TasksAssigned[k].IsChild == true)
                            {
                                AssignedTasksChildModel taskChildInfo = _context.AssignedTasksChildInfo.SingleOrDefault(task => task.Id == spaceCollections[i].Rooms[j].TasksAssigned[k].Id);
                                OneTaskDetails.IsRequestedApproval = taskChildInfo.IsRequestedApproval;
                            }


                            AllTasksHistory.Add(OneTaskDetails);
                            // }

                        }
                    }
                }

                // }
            }
            return AllTasksHistory;

        }

        public string GetTaskNameByTaskID(int taskId, List<SelectedTasksDTO> tasks)
        {

            string name = "";
            for (int i = 0; i < tasks.Count; i++)
            {
                if (taskId == tasks[i].Id)
                {
                    name = tasks[i].Task.Name + " " + tasks[i].Item.Name;
                }
            }
            return name;
        }


        public List<DefaultOptionsDTO> GetDefaultOptionsByUsername(string? username)
        {
            UserModel user = _context.UserInfo.SingleOrDefault(x => x.Username == username);
            return GetDefaultOptionsByUserId(user.Id);
        }
        public List<DefaultOptionsDTO> GetDefaultOptionsByUserId(int id)
        {

            List<DefaultOptionsDTO> MyAndInvitedCollections = new List<DefaultOptionsDTO>();

            List<DefaultOptionsDTO> MyCollections = GetDefaultCollectionsByUserId(id);
            List<DefaultOptionsDTO> InvitedCollections = GetSharedDefaultCollectionsByUserId(id);
            MyAndInvitedCollections.AddRange(MyCollections);
            MyAndInvitedCollections.AddRange(InvitedCollections);

            return MyAndInvitedCollections;
        }

        public List<DefaultOptionsDTO> GetCollectionsRoomsByUsername(string? username)
        {
            UserModel findUser = _context.UserInfo.SingleOrDefault(user => user.Username == username);

            return GetDefaultCollectionsByUserId(findUser.Id);
        }

        public List<DefaultOptionsDTO> GetDefaultCollectionsByUserId(int UserId)
        {
            List<DefaultOptionsDTO> SpaceCollectionsDTO = new List<DefaultOptionsDTO>();
            List<SpaceCollectionModel> collections = _context.SpaceCollectionInfo.Where(item => item.UserId == UserId && item.IsDeleted == false).ToList();

            if (collections != null)
            {
                for (int i = 0; i < collections.Count; i++)
                {
                    DefaultOptionsDTO oneCollection = new DefaultOptionsDTO();
                    oneCollection.Id = collections[i].Id;
                    oneCollection.CollectionName = collections[i].CollectionName;
                    oneCollection.Rooms = GetRoomsByCollectionID(collections[i].Id);
                    SpaceCollectionsDTO.Add(oneCollection);
                }
            }

            return SpaceCollectionsDTO;
        }

        public List<SpaceInfoModel> GetRoomsByCollectionID(int id)
        {
            return _context.SpaceInfo.Where(item => item.CollectionId == id).ToList();
        }

        public List<DefaultOptionsDTO> GetSharedDefaultCollectionsByUserId(int id)
        {

            List<DefaultOptionsDTO> sharedCollections = new List<DefaultOptionsDTO>();
            UserModel findInvited = _context.UserInfo.SingleOrDefault(user => user.Id == id);
            List<SharedSpacesModel> sharedCollection = _context.SharedSpacesInfo.Where(collection => collection.InvitedUsername == findInvited.Username && (collection.IsDeleted == false && collection.IsAccepted == true)).ToList();

            for (int i = 0; i < sharedCollection.Count; i++)
            {
                SpaceCollectionModel findCollection = _context.SpaceCollectionInfo.SingleOrDefault(item => item.Id == sharedCollection[i].CollectionId);

                DefaultOptionsDTO oneCollection = new DefaultOptionsDTO();
                oneCollection.Id = sharedCollection[i].CollectionId;
                oneCollection.CollectionName = findCollection.CollectionName;
                oneCollection.Rooms = GetRoomsByCollectionID(sharedCollection[i].Id);

                sharedCollections.Add(oneCollection);
            }

            return sharedCollections;

        }

        public List<CollectionsDTO> GetSharedCollectionsDetailsByUsername(string? username)
        {
            UserModel userInfo = _context.UserInfo.SingleOrDefault(user => user.Username == username);

            return GetSharedCollectionsDetailsByID(userInfo.Id);
        }

        public List<CollectionsDTO> GetSharedCollectionsDetailsByID(int userId)
        {
            List<CollectionsDTO> SpaceCollectionsDTO = new List<CollectionsDTO>();
            List<SpaceCollectionModel> collections = new List<SpaceCollectionModel>();

            collections = _context.SpaceCollectionInfo.Where(item => item.UserId == userId && item.IsDeleted == false).ToList();

            if (collections != null)
            {
                for (int i = 0; i < collections.Count; i++)
                {
                    CollectionsDTO oneCollection = new CollectionsDTO();
                    oneCollection.Id = collections[i].Id;
                    oneCollection.CollectionName = collections[i].CollectionName;
                    oneCollection.IsDeleted = collections[i].IsDeleted;
                    oneCollection.SharedWith = GetSharedCollectionWithByCollectionId(collections[i].Id);

                    SpaceCollectionsDTO.Add(oneCollection);
                }
            }

            return SpaceCollectionsDTO;
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

        public UserModel GetUserByUserName(string? username)
        {
            return _context.UserInfo.SingleOrDefault(user => user.Username == username);
        }


        public CollectionsDTO GetCollectionDTOByCollectionID(int id)
        {
            SpaceCollectionModel collections = _context.SpaceCollectionInfo.SingleOrDefault(item => item.Id == id);
            CollectionsDTO oneCollection = new CollectionsDTO();
            if (collections != null)
            {
                oneCollection.Id = collections.Id;
                oneCollection.CollectionName = collections.CollectionName;
                oneCollection.IsDeleted = collections.IsDeleted;
                oneCollection.Rooms = _spaceService.GetRoomsByCollectionID(collections.Id);
                oneCollection.SharedWith = _sharedSpaces.GetSharedCollectionWithByCollectionId(collections.Id);
            }

            return oneCollection;
        }

    }
}