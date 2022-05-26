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
            return _context.SaveChanges() !=0;
        }
        //edit or update
        
        public SpaceCollectionModel GetSpaceCollectionById(int Id)
        {
            return _context.SpaceCollectionInfo.SingleOrDefault(item => item.Id == Id);
        }

        public IEnumerable<SpaceCollectionModel> GetSpaceCollectionByUserId(int UserId)
        {
            return _context.SpaceCollectionInfo.Where(item => item.UserId == UserId);
        }
        public bool DeleteSpaceCollectionById(int Id)
        {
            SpaceCollectionModel foundSpaceCollection = GetSpaceCollectionById(Id);
            bool result = false;
            bool isDeleted = false;
            if(foundSpaceCollection != null)
            {
                foundSpaceCollection.IsDeleted = true;
                _context.Update<SpaceCollectionModel>(foundSpaceCollection);
                isDeleted =_context.SaveChanges()!=0;
            }
            List<DefaultCollectionModel> findDefault = _context.DefaultCollectionInfo.Where(item => item.CollectionId == Id).ToList();
            if(isDeleted)
            {
                 if(findDefault.Count>0)
            {
                for (int i = 0; i < findDefault.Count; i++)
                {
                    findDefault[i].IsDeleted = true;
                    _context.Update<DefaultCollectionModel>(findDefault[i]);
                    result = _context.SaveChanges() != 0;
                }
            }
            }
           
            return result;
        }

        //update space collection name
        public bool UpdateSpaceCollectionNameByUserId(int UserId, string CollectionName)
        {
            bool result = false;
            SpaceCollectionModel SpaceCollection = GetSpaceCollectionById(UserId);
            if(SpaceCollection !=null)
            {
                SpaceCollection.CollectionName= CollectionName;
                _context.Update<SpaceCollectionModel>(SpaceCollection);
                result = _context.SaveChanges()!=0;
            }
            return result;
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
                   oneCollection.Rooms = _spaceService.GetRoomsByCollectionID(collections[i].Id);
                  oneCollection.SharedWith = _sharedSpaces.GetSharedCollectionWithByCollectionId(collections[i].Id);

                    SpaceCollectionsDTO.Add(oneCollection);
                }
            }

            return SpaceCollectionsDTO;
        }

        public List<TasksHistoryDTO> GetAllTasksHistoryForMembers(int userId)
        {
            bool start = false;
            List<TasksHistoryDTO> AllTasksHistory = new List<TasksHistoryDTO>();
            List<string> dates = new List<string>();
            for (int d = 0; d < 50; d++)
            {

                DateTime day = DateTime.Today.AddDays(-d);
                dates.Add(day.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ss.sss0Z"));
                if(d==49){
                    start=true;
                }
            }

            if(start){

           

            List<CollectionsDTO> spaceCollections = GetCollectionByUserId(userId);


            if (spaceCollections != null)
            {

                for (int i = 0; i < spaceCollections.Count; i++)
                {
                    for (int j = 0; j < spaceCollections[i].Rooms.Count; j++)
                    {
                        for (int k = 0; k < spaceCollections[i].Rooms[j].TasksAssigned.Count; k++)
                        {
                            if (dates.Contains(spaceCollections[i].Rooms[j].TasksAssigned[k].DateScheduled))
                            {
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
                            }

                        }
                    }
                }

            }
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



    }
}