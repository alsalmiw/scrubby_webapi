using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using scrubby_webapi.Models;
using scrubby_webapi.Services.Context;

namespace scrubby_webapi.Services
{
    public class AssignedTasksUsersService
    {
        private readonly DataContext _context;

        public AssignedTasksUsersService(DataContext context)
        {
            _context = context;
        }

        
        public bool AddUserAssignedTasks(List<AssignedTasksUsersModel> listOfAssignedTasks)
        {
            bool result = false;
            for(int i = 0; i < listOfAssignedTasks.Count; i++){

                AssignedTasksUsersModel foundTask = _context.AssignedTasksUsersInfo.SingleOrDefault(task => task.UserId == listOfAssignedTasks[i].UserId && task.SpaceId == listOfAssignedTasks[i].SpaceId && task.AssignedTaskId == listOfAssignedTasks[i].AssignedTaskId && task.DateCreated== listOfAssignedTasks[i].DateCreated && task.IsDeleted==false);
                if(foundTask == null)
                {
                     _context.Add(listOfAssignedTasks[i]);
                    result = _context.SaveChanges() !=0;
                }
                else{
                    foundTask.IsDeleted = true;
                    _context.Update<AssignedTasksUsersModel>(foundTask);
                    result = _context.SaveChanges() !=0;
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
            if(foundUser != null)
            {
                //A user was foundUser
                foundUser.AssignedTaskId = SelectedTasksId;
                _context.Update<AssignedTasksUsersModel>(foundUser);
               result =  _context.SaveChanges() != 0;
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
             if(findTask != null){
                DateTime thisDay = DateTime.Today;
                findTask.IsCompleted = true;
                findTask.DateCompleted = thisDay.ToString("d");
               _context.Update<AssignedTasksUsersModel>(findTask);
               result =_context.SaveChanges() != 0;
               }
               return  result;
        }
        
         









        

    }
}