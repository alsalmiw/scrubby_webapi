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
    public class DefaultCollectionDependentService
    {
         private readonly DataContext _context;
        public DefaultCollectionDependentService(DataContext context)
        {
            _context = context; 
        }

        public ScheduleCollectionsDTO ChildDefaultSchedule(int childId)
        {
            ScheduleCollectionsDTO collectionDTO = new ScheduleCollectionsDTO();

            DependentModel findChild = _context.DependentInfo.SingleOrDefault(child => child.Id == childId);

            DefaultCollectionDependentModel findDefault = _context.DefaultCollectionDependentInfo.SingleOrDefault(collection => collection.ChildId == findChild.Id && collection.IsDefault==true && collection.IsDeleted == false);

            List<SpaceCollectionModel> collectionsByUserId = _context.SpaceCollectionInfo.Where(collection => collection.UserId == findChild.UserId).ToList();

            if(findDefault == null)
            {
                collectionDTO.Id = collectionsByUserId[0].Id;
                collectionDTO.CollectionName = collectionsByUserId[0].CollectionName;
                 collectionDTO.Rooms = GetDefaultScheduledRoomsByCollectionID(collectionsByUserId[0].Id, childId);
            }else{
                SpaceCollectionModel defaultCollection =  _context.SpaceCollectionInfo.SingleOrDefault(collection => collection.Id == findDefault.CollectionId);

                collectionDTO.Id = defaultCollection.Id;
                collectionDTO.CollectionName = defaultCollection.CollectionName;
                 collectionDTO.Rooms = GetDefaultScheduledRoomsByCollectionID(defaultCollection.Id,  childId);
            }
            return collectionDTO;
        }



        public List<ScheduleSpacesDTO> GetDefaultScheduledRoomsByCollectionID(int id, int childId)
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

                    oneSpace.TasksAssigned = GetAllAssignedTasksByChildId(childId, spaces[i].Id);

                    spaceByCollectionIdDTO.Add(oneSpace);
                }
            }

            return spaceByCollectionIdDTO;
        }

        // public List<SelectedTasksDTO>GetAllAssignedTasksByUserId(int id, int spaceId){
        //         List<AssignedTasksUsersModel> AssignedUser = _context.AssignedTasksUsersInfo.Where(assignment => assignment.UserId == id && assignment.IsDeleted==false && assignment.SpaceId == spaceId).ToList();

        //         List<SelectedTasksDTO> AssignedTasks = new List<SelectedTasksDTO>();


        //         if(AssignedUser.Count!=0)
        //         {
        //              for(int i = 0; i < AssignedUser.Count; i++)
        //             {
        //             SelectedTasksDTO oneTask = new SelectedTasksDTO();
        //             oneTask.Id = AssignedUser[i].Id;
        //             oneTask.DateScheduled = AssignedUser[i].DateCreated;
        //             oneTask.DateCompleted= AssignedUser[i].DateCompleted;
        //             oneTask.IsCompleted = AssignedUser[i].IsCompleted;
        //             SelectedTasksModel taskInfo = _context.SelectedTasksInfo.SingleOrDefault(selectedTask => selectedTask.Id == AssignedUser[i].AssignedTaskId);

        //             oneTask.Task = GetTaskByTaskID(taskInfo.TaskId);
        //             oneTask.Item = _context.SpaceItemsStaticAPIInfo.SingleOrDefault(item => item.Id == taskInfo.ItemId);
        //             AssignedTasks.Add(oneTask);

        //             }
        //         }
               
        //     return AssignedTasks;
        // }

         public TasksInfoStaticAPIModel GetTaskByTaskID(int id)
        {
            return _context.TasksInfoStaticAPIInfo.SingleOrDefault(task => task.Id == id);
        }

        // public List<ScheduleSpacesDTO> GetScheduledRoomsByCollectionIDKidsId (int id, int childId)
        // {
        //      List<ScheduleSpacesDTO> spaceByCollectionIdDTO = new List<ScheduleSpacesDTO>();
        //     List<SpaceInfoModel> spaces = _context.SpaceInfo.Where(space => space.CollectionId == id).ToList();

        //     if (spaces != null)
        //     {
        //         for (int i = 0; i < spaces.Count; i++)
        //         {
        //             ScheduleSpacesDTO oneSpace = new ScheduleSpacesDTO();
        //             oneSpace.Id = spaces[i].Id;
        //             oneSpace.SpaceName = spaces[i].SpaceName;
        //             oneSpace.SpaceCategory = spaces[i].SpaceCategory;

        //             oneSpace.TasksAssigned = GetAllAssignedTasksByChildId(childId, spaces[i].Id);

        //             spaceByCollectionIdDTO.Add(oneSpace);
        //         }
        //     }

        //     return spaceByCollectionIdDTO;
        // }

        public List<SelectedTasksDTO>GetAllAssignedTasksByChildId(int id, int spaceId){
                List<AssignedTasksChildModel> AssignedUser = _context.AssignedTasksChildInfo.Where(assignment => assignment.ChildId == id && assignment.IsDeleted==false && assignment.SpaceId == spaceId).ToList();

                List<SelectedTasksDTO> AssignedTasks = new List<SelectedTasksDTO>();


                if(AssignedUser!=null)
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

           public bool CreateChildDefaultSchedule(int childId, int collectionId)
        {
            List <DefaultCollectionDependentModel> findAllEntries = _context.DefaultCollectionDependentInfo.Where(collection => collection.ChildId == childId && collection.IsDeleted==false).ToList();
            for(int i = 0; i < findAllEntries.Count; i++){
                findAllEntries[i].IsDefault = false;
                _context.Update<DefaultCollectionDependentModel>(findAllEntries[i]);
                _context.SaveChanges();
            }
            DefaultCollectionDependentModel AddDefault = new DefaultCollectionDependentModel();
            AddDefault.Id = 0;
            AddDefault.ChildId = childId;
            AddDefault.CollectionId =collectionId;
            AddDefault.IsDefault = true;
            AddDefault.IsDeleted=false;

             _context.Add(AddDefault);
            return _context.SaveChanges() !=0;
        }
    }
}