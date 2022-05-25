using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using scrubby_webapi.Models;
using scrubby_webapi.Models.DTO;
using scrubby_webapi.Services.Context;

namespace scrubby_webapi.Services
{
    public class AssignedTasksUsersService
    {
        private readonly DataContext _context;
        private readonly AssignedTasksChildService _childAssignedTasks;

        public AssignedTasksUsersService(DataContext context,  AssignedTasksChildService childAssigned)
        {
            _context = context;
            _childAssignedTasks=childAssigned;
        }


        public bool AddUserAssignedTasks(List<AssignedTasksUsersModel> listOfAssignedTasks)
        {
            bool result = false;
            for (int i = 0; i < listOfAssignedTasks.Count; i++)
            {

                AssignedTasksUsersModel foundTask = _context.AssignedTasksUsersInfo.SingleOrDefault(task => task.UserId == listOfAssignedTasks[i].UserId && task.SpaceId == listOfAssignedTasks[i].SpaceId && task.AssignedTaskId == listOfAssignedTasks[i].AssignedTaskId && task.DateCreated == listOfAssignedTasks[i].DateCreated && task.IsDeleted == false);
                if (foundTask == null)
                {
                    _context.Add(listOfAssignedTasks[i]);
                    result = _context.SaveChanges() != 0;
                }
                else
                {
                    foundTask.IsDeleted = true;
                    _context.Update<AssignedTasksUsersModel>(foundTask);
                    result = _context.SaveChanges() != 0;
                }
            }

            return result;
        }

        public bool DeleteAssignedTaskUserByTaskId(int Id)
        {
            AssignedTasksUsersModel AssignedTask = GetAllAssignedTasksById(Id);

            AssignedTask.IsDeleted = true;
            _context.Update<AssignedTasksUsersModel>(AssignedTask);
            return _context.SaveChanges() != 0;
        }
        public AssignedTasksUsersModel GetAllAssignedTasksById(int id)
        {
            return _context.AssignedTasksUsersInfo.SingleOrDefault(task => task.Id == id);
        }

        public IEnumerable<AssignedTasksUsersModel> GetAllAssignedTasksUsersByUserId(int userId)
        {
            return _context.AssignedTasksUsersInfo.Where(user => user.Id == userId);
        }





        public bool UpdateAssignedTasksUsers(int id, int SelectedTasksId)
        {
            AssignedTasksUsersModel foundUser = GetAllAssignedTasksById(id);

            bool result = false;
            if (foundUser != null)
            {
                //A user was foundUser
                foundUser.AssignedTaskId = SelectedTasksId;
                _context.Update<AssignedTasksUsersModel>(foundUser);
                result = _context.SaveChanges() != 0;
            }

            return result;
        }

        //Need Help on creating
        public AssignedTasksUsersModel GetDateCreatedAssignedTasksUsersById(int Id)
        {
            return _context.AssignedTasksUsersInfo.SingleOrDefault(item => item.Id == Id);
        }

        public AssignedTasksUsersModel GetDateCompletedAssignedTasksUsersById(int Id)
        {
            return _context.AssignedTasksUsersInfo.SingleOrDefault(item => item.Id == Id);
        }

        public IEnumerable<AssignedTasksUsersModel> GetDateCreatedAssignedTasksUsersByUserId(int userId)
        {
            return _context.AssignedTasksUsersInfo.Where(user => user.Id == userId);
        }

        public IEnumerable<AssignedTasksUsersModel> GetDateCompletedAssignedTasksUsersByUserId(int userId)
        {
            return _context.AssignedTasksUsersInfo.Where(user => user.Id == userId);
        }

        public bool UpdateUserTaskToCompleted(int TaskId)
        {
            AssignedTasksUsersModel findTask = _context.AssignedTasksUsersInfo.SingleOrDefault(item => item.Id == TaskId);
            bool result = false;
            if (findTask != null)
            {
                DateTime thisDay = DateTime.Today;
                findTask.IsCompleted = true;
                findTask.DateCompleted = thisDay.ToString("d");
                _context.Update<AssignedTasksUsersModel>(findTask);
                result = _context.SaveChanges() != 0;
            }
            return result;
        }


        // public List<TasksHistoryDTO> GetAllTasksHistoryForMembers(int userId)
        // {
        //     List<TasksHistoryDTO> AllTasksHistory = new List<TasksHistoryDTO>();
        //     List<string> dates = new List<string>();
        //     for (int d = 0; d < 50; d++)
        //     {

        //         DateTime day = DateTime.Today.AddDays(-d);
        //         dates.Add(day.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ss.sss0Z"));
        //     }



        //     List<CollectionsDTO> spaceCollections = _spaceCollection.GetCollectionByUserId(userId);
        //     if (spaceCollections != null)
        //     {

        //         for (int i = 0; i < spaceCollections.Count; i++)
        //         {
        //             for (int j = 0; j < spaceCollections[i].Rooms.Count; j++)
        //             {
        //                 for (int k = 0; k < spaceCollections[i].Rooms[j].TasksAssigned.Count; k++)
        //                 {
        //                     if (dates.Contains(spaceCollections[i].Rooms[j].TasksAssigned[k].DateScheduled))
        //                     {
        //                         TasksHistoryDTO OneTaskDetails = new TasksHistoryDTO();
        //                         OneTaskDetails.TaskSpace = spaceCollections[i].CollectionName;
        //                         OneTaskDetails.TaskRoom = spaceCollections[i].Rooms[j].SpaceName;
        //                         OneTaskDetails.MemberId = spaceCollections[i].Rooms[j].TasksAssigned[k].UserId;

        //                         OneTaskDetails.IsChild = spaceCollections[i].Rooms[j].TasksAssigned[k].IsChild;
        //                         OneTaskDetails.TaskId = spaceCollections[i].Rooms[j].TasksAssigned[k].AssignedTaskId;

        //                         OneTaskDetails.Name = spaceCollections[i].Rooms[j].TasksAssigned[k].Name;
        //                         OneTaskDetails.TaskName = GetTaskNameByTaskID(spaceCollections[i].Rooms[j].TasksAssigned[k].AssignedTaskId, spaceCollections[i].Rooms[j].Tasks);
        //                         OneTaskDetails.IsCompleted = spaceCollections[i].Rooms[j].TasksAssigned[k].IsCompleted;

        //                         OneTaskDetails.DateScheduled = spaceCollections[i].Rooms[j].TasksAssigned[k].DateScheduled;
        //                         OneTaskDetails.DateCompleted = spaceCollections[i].Rooms[j].TasksAssigned[k].DateCompleted;
        //                         if (spaceCollections[i].Rooms[j].TasksAssigned[k].IsChild == true)
        //                         {
        //                             AssignedTasksChildModel taskChildInfo = _context.AssignedTasksChildInfo.SingleOrDefault(task => task.Id == spaceCollections[i].Rooms[j].TasksAssigned[k].Id);
        //                             OneTaskDetails.IsRequestedApproval = taskChildInfo.IsRequestedApproval;
        //                         }


        //                         AllTasksHistory.Add(OneTaskDetails);
        //                     }

        //                 }
        //             }
        //         }

        //     }
        //     return AllTasksHistory;

        // }



        // public string GetTaskNameByTaskID(int taskId, List<SelectedTasksDTO> tasks)
        // {

        //     string name = "";
        //     for (int i = 0; i < tasks.Count; i++)
        //     {
        //         if (taskId == tasks[i].Id)
        //         {
        //             name = tasks[i].Task.Name + " " + tasks[i].Item.Name;
        //         }
        //     }
        //     return name;
        // }

public List<AssignedTasksDTO> GetAllAssignedTasksBySpaceId(int id)
        {

            List<AssignedTasksDTO> AssignedTasks = new List<AssignedTasksDTO>();
            List<AssignedTasksDTO> AssignedUsers = GetAllAssignedUserTasksBySpaceId(id);
            List<AssignedTasksDTO> AssignedChildren = _childAssignedTasks.GetAllAssignedChildTasksBySpaceId(id);

            if (AssignedUsers.Count != 0)
            {
                for (int i = 0; i < AssignedUsers.Count; i++)
                {
                    AssignedTasks.Add(AssignedUsers[i]);
                }
            }

            if (AssignedChildren.Count != 0)
            {
                for (int i = 0; i < AssignedChildren.Count; i++)
                {
                    AssignedTasks.Add(AssignedChildren[i]);
                }

            }

            return AssignedTasks;

        }



     public List<AssignedTasksDTO> GetAllAssignedUserTasksBySpaceId(int id)
        {

            List<AssignedTasksUsersModel> AssignedUsers = _context.AssignedTasksUsersInfo.Where(assignment => assignment.SpaceId == id && assignment.IsDeleted == false).ToList();

            List<AssignedTasksDTO> AssignedTasks = new List<AssignedTasksDTO>();


            if (AssignedUsers.Count != 0)
            {
                for (int i = 0; i < AssignedUsers.Count; i++)
                {
                    UserModel findUser = _context.UserInfo.SingleOrDefault(user => user.Id == AssignedUsers[i].UserId);

                    AssignedTasksDTO oneTask = new AssignedTasksDTO();
                    oneTask.Id = AssignedUsers[i].Id;
                    oneTask.UserId = AssignedUsers[i].UserId;
                    oneTask.Name = findUser.Name;
                    oneTask.AssignedTaskId = AssignedUsers[i].AssignedTaskId;
                    oneTask.DateScheduled = AssignedUsers[i].DateCreated;
                    oneTask.DateCompleted = AssignedUsers[i].DateCompleted;
                    oneTask.IsCompleted = AssignedUsers[i].IsCompleted;
                    oneTask.IsChild = false;
                    AssignedTasks.Add(oneTask);
                }
            }

            return AssignedTasks;


        }








    }
}