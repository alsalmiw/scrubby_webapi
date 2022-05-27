using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using scrubby_webapi.Models;
using scrubby_webapi.Models.Static;
using scrubby_webapi.Models.DTO;
using scrubby_webapi.Services.Context;

namespace scrubby_webapi.Services
{
    public class DependentService
    {
        private readonly DataContext _context;
        public DependentService(DataContext context)
        {
            _context = context;
        }

        public bool AddDependent(DependentModel newDependent)
        {
            _context.Add(newDependent);
            return _context.SaveChanges() != 0;


        }
        public bool UpdateDependent(DependentModel dependentUpdate)
        {
            _context.Update<DependentModel>(dependentUpdate);
            return _context.SaveChanges() != 0;

        }

        public IEnumerable<DependentModel> GetDependantByUserId(int userId)
        {
            return _context.DependentInfo.Where(d => d.UserId == userId && d.IsDeleted == false);
        }

        public DependentModel GetDependentById(int id)
        {
            return _context.DependentInfo.SingleOrDefault(d => d.Id == id);
        }
        public DependentModel NewCoinAmount(DependentModel newAmount)
        {
            DependentModel childInfo = GetDependentById(newAmount.Id);

            bool result = false;
            if (childInfo != null)
            {
                //A user was foundUser
                childInfo.DependentCoins = newAmount.DependentCoins;
                _context.Update<DependentModel>(childInfo);
                result = _context.SaveChanges() != 0;


            }
            return result ? childInfo : null;
        }

        public DependentModel UpdatedChildPassCode(DependentModel passCodeUpdate)
        {
            DependentModel childInfo = GetDependentById(passCodeUpdate.Id);

            bool result = false;
            if (childInfo != null)
            {
                childInfo.DependentPassCode = passCodeUpdate.DependentPassCode;
                _context.Update<DependentModel>(childInfo);
                result = _context.SaveChanges() != 0;
            }
            return result ? childInfo : null;
        }

        public DependentDTO GetDependantDTOByChildId(int childId)
        {

            DependentModel childInfo = _context.DependentInfo.SingleOrDefault(child => child.Id == childId);
            DependentDTO oneChild = new DependentDTO();

            if (childInfo != null)
            {
                oneChild.Id = childInfo.Id;
                oneChild.UserId = childInfo.UserId;
                oneChild.DependentName = childInfo.DependentName;
                oneChild.DependentAge = childInfo.DependentAge;
                oneChild.DependentPhoto = childInfo.DependentPhoto;
                oneChild.DependentCoins = childInfo.DependentCoins;
                oneChild.DependentPoints = childInfo.DependentPoints;
                oneChild.DependentPassCode = childInfo.DependentPassCode;
                oneChild.ScheduledTasks = GetScheduleCollectionsKidsUsingUserId(childInfo.UserId, childInfo.Id);
            }

            return oneChild;
        }

        public List <ScheduleCollectionsDTO> GetScheduleCollectionsKidsUsingUserId(int userId, int kidsId)
        {
           List<ScheduleCollectionsDTO> SpaceCollectionsDTO = new List<ScheduleCollectionsDTO>();
            List<SpaceCollectionModel> collections = _context.SpaceCollectionInfo.Where(item => item.UserId == userId).ToList();

            if (collections != null)
            {
                for (int i = 0; i < collections.Count; i++)
                {
                    ScheduleCollectionsDTO oneCollection = new ScheduleCollectionsDTO();
                    oneCollection.Id = collections[i].Id;
                    oneCollection.CollectionName = collections[i].CollectionName;
                    oneCollection.Rooms = GetScheduledRoomsByCollectionIDKidsId(collections[i].Id, kidsId);
                    SpaceCollectionsDTO.Add(oneCollection);
                }
            }

            return SpaceCollectionsDTO;
        }

         public List<ScheduleSpacesDTO> GetScheduledRoomsByCollectionIDKidsId (int id, int childId)
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

           public DependentModel GetDependantByChildId (int childId)
        {
              return _context.DependentInfo.SingleOrDefault(child => child.Id == childId);
        }

            public DependentModel UpdateDependentCoinsAndPoints (DependentModel newPointsAndCoins)
        {
            DependentModel childInfo = GetDependentById(newPointsAndCoins.Id);

            bool result = false;
            if(childInfo != null)
            {
                childInfo.DependentCoins +=  newPointsAndCoins.DependentCoins;
                childInfo.DependentPoints += newPointsAndCoins.DependentCoins;
                _context.Update<DependentModel>(childInfo);
                result = _context.SaveChanges() != 0;
            }

            return result ? childInfo : null;
        }

        public bool ChangeChildName (ChildNameDTO NewName)
        {
            DependentModel findChild = _context.DependentInfo.SingleOrDefault(child => child.Id ==NewName.ChildId);
            findChild.DependentName = NewName.FullName;
             _context.Update<DependentModel>(findChild);
         return _context.SaveChanges() != 0;

        }


    }
}
