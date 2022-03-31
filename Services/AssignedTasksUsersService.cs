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
            return _context.AssignedTasksUsersInfo.SingleOrDefault(user => user.Id = id);
        }

        public AssignedTasksUsersModel GetAllAssignedTasksUsersByUserId(int userId)
        {
            return _context.AssignedTasksUsersInfo.SingleOrDefault(user => user.Id == userId);
        }



        public bool UpdateAssignedTasksUsers(int id, int SelectedTasksId)
        {
            AssignedTasksUsersModel foundUser = GetAllAssignedTasksUsersById(id);

            bool result = false;
            if(foundUser != null)
            {
                //A user was foundUser
                foundUser.SelectedTasksId = SelectedTasksId;
                _context.Update<UserModel>(foundUser);
               result =  _context.SaveChanges() != 0;
            }

            return result;
        }

        //Need Help on creating
        
         









        

    }
}