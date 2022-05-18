using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using scrubby_webapi.Models;
using scrubby_webapi.Models.DTO;
using scrubby_webapi.Models.Static;
using scrubby_webapi.Services.Context;


namespace scrubby_webapi.Services
{
    public class DefaultCollectionService
    {
         private readonly DataContext _context;
        public DefaultCollectionService(DataContext context)
        {
            _context = context; 
        }

        public ScheduleCollectionsDTO UserDefaultSchedule(string username)
        {
            ScheduleCollectionsDTO collectionDTO = new ScheduleCollectionsDTO();

            UserModel findUser = _context.UserInfo.SingleOrDefault(user => user.Username == username);

            DefaultCollectionModel findDefault = _context.DefaultCollectionInfo.SingleOrDefault(collection => collection.UserId == findUser.Id && collection.IsDefault==true && collection.IsDeleted==false);

            List<SpaceCollectionModel> collectionsByUserId = _context.SpaceCollectionInfo.Where(collection => collection.UserId == findUser.Id).ToList();

            if(findDefault == null)
            {
                collectionDTO.Id = collectionsByUserId[0].Id;
                collectionDTO.CollectionName = collectionsByUserId[0].CollectionName;
                 collectionDTO.Rooms = GetDefaultScheduledRoomsByCollectionID(collectionsByUserId[0].Id, findUser.Id);
            }else{
                SpaceCollectionModel defaultCollection =  _context.SpaceCollectionInfo.SingleOrDefault(collection => collection.Id == findDefault.CollectionId);

                collectionDTO.Id = defaultCollection.Id;
                collectionDTO.CollectionName = defaultCollection.CollectionName;
                 collectionDTO.Rooms = GetDefaultScheduledRoomsByCollectionID(defaultCollection.Id, findUser.Id);
            }
            return collectionDTO;
        }



        public List<ScheduleSpacesDTO> GetDefaultScheduledRoomsByCollectionID(int id, int userId)
        {
            List<ScheduleSpacesDTO> spaceByCollectionIdDTO = new List<ScheduleSpacesDTO>();
            List<SpaceInfoModel> spaces = _context.SpaceInfo.Where(space => space.CollectionId == id).ToList();

            if (spaces != null)
            {
                for (int i = 0; i < spaces.Count; i++)
                {
                    ScheduleSpacesDTO oneSpace = new ScheduleSpacesDTO();
                    oneSpace.Id = spaces[i].Id;
                    oneSpace.SpaceName = spaces[i].SpaceName;
                    oneSpace.SpaceCategory = spaces[i].SpaceCategory;

                    oneSpace.TasksAssigned = GetAllAssignedTasksByUserId(userId, spaces[i].Id);

                    spaceByCollectionIdDTO.Add(oneSpace);
                }
            }

            return spaceByCollectionIdDTO;
        }

        public List<SelectedTasksDTO>GetAllAssignedTasksByUserId(int id, int spaceId){
                List<AssignedTasksUsersModel> AssignedUser = _context.AssignedTasksUsersInfo.Where(assignment => assignment.UserId == id && assignment.IsDeleted==false && assignment.SpaceId == spaceId).ToList();

                List<SelectedTasksDTO> AssignedTasks = new List<SelectedTasksDTO>();


                if(AssignedUser.Count!=0)
                {
                     for(int i = 0; i < AssignedUser.Count; i++)
                    {
                    SelectedTasksDTO oneTask = new SelectedTasksDTO();
                    oneTask.Id = AssignedUser[i].Id;
                    oneTask.DateScheduled = AssignedUser[i].DateCreated;
                    oneTask.DateCompleted= AssignedUser[i].DateCompleted;
                    oneTask.IsCompleted = AssignedUser[i].IsCompleted;
                    SelectedTasksModel taskInfo = _context.SelectedTasksInfo.SingleOrDefault(selectedTask => selectedTask.Id == AssignedUser[i].AssignedTaskId);

                    oneTask.Task = GetTaskByTaskID(taskInfo.TaskId);
                    oneTask.Item = _context.SpaceItemsStaticAPIInfo.SingleOrDefault(item => item.Id == taskInfo.ItemId);
                    AssignedTasks.Add(oneTask);

                    }
                }
               
            return AssignedTasks;
        }

         public TasksInfoStaticAPIModel GetTaskByTaskID(int id)
        {
            return _context.TasksInfoStaticAPIInfo.SingleOrDefault(task => task.Id == id);
        }


    }
}