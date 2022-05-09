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

        public AssignedTasksUsersModel GetAllAssignedTasksUsersById(int id)
        {
            return _context.AssignedTasksUsersInfo.SingleOrDefault(user => user.Id == id);
        }

        public IEnumerable<AssignedTasksUsersModel> GetAllAssignedTasksUsersByUserId(int userId)
        {
            return _context.AssignedTasksUsersInfo.Where(user => user.Id == userId);
        }

        



        public bool UpdateAssignedTasksUsers(int id, int SelectedTasksId)
        {
            AssignedTasksUsersModel foundUser = GetAllAssignedTasksUsersById(id);

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
        
         









        

    }
}