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

            DefaultCollectionDependentModel findChildDefault = _context.DefaultCollectionDependentInfo.SingleOrDefault(collection => collection.ChildId == findChild.Id && collection.IsDefault == true && collection.IsDeleted == false);

            List<SpaceCollectionModel> collectionsByUserId = _context.SpaceCollectionInfo.Where(collection => collection.UserId == findChild.UserId && collection.IsDeleted == false).ToList();

            if (findChildDefault == null)
            {
                DefaultCollectionModel findParentDefault = _context.DefaultCollectionInfo.SingleOrDefault(collection => collection.UserId == findChild.UserId && collection.IsDefault == true && collection.IsDeleted == false);
                if (findParentDefault != null)
                {
                    SpaceCollectionModel parentDefaultCollection = _context.SpaceCollectionInfo.SingleOrDefault(collection => collection.Id == findParentDefault.CollectionId);
                    collectionDTO.Id = parentDefaultCollection.Id;
                    collectionDTO.CollectionName = parentDefaultCollection.CollectionName;
                    collectionDTO.Rooms = GetDefaultScheduledRoomsByCollectionID(parentDefaultCollection.Id, childId);
                }
                else
                {
                    collectionDTO.Id = collectionsByUserId[0].Id;
                    collectionDTO.CollectionName = collectionsByUserId[0].CollectionName;
                    collectionDTO.Rooms = GetDefaultScheduledRoomsByCollectionID(collectionsByUserId[0].Id, childId);
                }


            }
            else
            {
                SpaceCollectionModel defaultCollection = _context.SpaceCollectionInfo.SingleOrDefault(collection => collection.Id == findChildDefault.CollectionId);

                collectionDTO.Id = defaultCollection.Id;
                collectionDTO.CollectionName = defaultCollection.CollectionName;
                collectionDTO.Rooms = GetDefaultScheduledRoomsByCollectionID(defaultCollection.Id, childId);
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



        public List<SelectedTasksDTO> GetAllAssignedTasksByChildId(int id, int spaceId)
        {
            List<AssignedTasksChildModel> AssignedUser = _context.AssignedTasksChildInfo.Where(assignment => assignment.ChildId == id && assignment.IsDeleted == false && assignment.SpaceId == spaceId).ToList();

            List<SelectedTasksDTO> AssignedTasks = new List<SelectedTasksDTO>();


            if (AssignedUser != null)
            {
                for (int i = 0; i < AssignedUser.Count; i++)
                {
                    SelectedTasksDTO oneTask = new SelectedTasksDTO();
                    oneTask.Id = AssignedUser[i].Id;
                    oneTask.DateScheduled = AssignedUser[i].DateCreated;
                    oneTask.IsDeleted = AssignedUser[i].IsDeleted;
                    oneTask.DateCompleted = AssignedUser[i].DateCompleted;
                    oneTask.IsCompleted = AssignedUser[i].IsCompleted;
                    oneTask.IsRequestedApproval = AssignedUser[i].IsRequestedApproval;
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

        public bool CreateChildDefaultSchedule(DefaultCollectionDependentModel newDefault)
        {
            bool isRemoved = false;
            DefaultCollectionDependentModel findAllEntries = _context.DefaultCollectionDependentInfo.SingleOrDefault(collection => collection.ChildId == newDefault.ChildId && collection.IsDefault == true && collection.IsDeleted==false);
            if (findAllEntries != null)
            {
                findAllEntries.IsDefault = false;
                _context.Update<DefaultCollectionDependentModel>(findAllEntries);
                isRemoved = _context.SaveChanges() != 0;
            }
            else{
                isRemoved = true;
            }
        
        bool result = false;
            if(isRemoved)
            {
                _context.DefaultCollectionDependentInfo.AddAsync(newDefault);
                result= _context.SaveChanges() !=0;
            }
             
                return result;
        }
      
    }
}