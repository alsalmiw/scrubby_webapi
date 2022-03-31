using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using scrubby_webapi.Models;
using scrubby_webapi.Services.Context;

namespace scrubby_webapi.Services
{
    public class AssignedTasksChildService
    {
        private readonly DataContext _context;
        public AssignedTasksChildService(DataContext context)
        {
            _context = context;
        }
        public bool CreateAssignedTasksChild(AssignedTasksChildModel AssignedTasksChildToCreate)
        {
            _context.Add(newCreatedAssignedTaskChild);
            return _context.SaveChanges() !=0;
        }

        //update date completed
        public bool UpdateAssignedTasksChildByIdAndDateCom(int Id, string? DateCompleted)
        {
            bool result =false;
            AssignedTasksChildModel AssignedTasks = GetAssignedTasksChildById(Id);
            if(AssignedTasks != null)
            {
                AssignedTasks.DateCompleted = DateCompleted;
                _context.Update<AssignedTasksChildModel>(AssignedTasks);
                result = _context.SaveChanges()!=0;
            }
            return result;
        }
        //update repeat
        public bool UpdateRepeatAssignedTasksChildByIdAndRepeat(int Id, int Repeat)
        {
            bool result =false;
            AssignedTasksChildModel AssignedTasks = GetAssignedTasksChildById(Id);
            if(AssignedTasks != null)
            {
                AssignedTasks.Repeat = Repeat;
                _context.Update<AssignedTasksChildModel>(AssignedTasks);
                result = _context.SaveChanges()!=0;
            }
            return result;
        }
        public AssignedTasksChildModel GetAssignedTasksChildById(int Id)
        {
            return _context.AssignedTasksChildInfo.SingleOrDefault(item => item.Id == Id);
        }
        public IEnumerable<AssignedTasksChildModel> GetAssignedTasksChildByUserId(int UserId)
        {
            return _context.AssignedTasksChildInfo.Where(item => item.Id == UserId);
        }


        public bool DeletedAssignedTasksChildById(int Id)
        {
            AssignedTasksChildModel AssignedTasksChild = GetAssignedTasksChildById(Id);

            AssignedTasksChild.IsDeleted = !AssignedTasksChild.IsDeletedIsDeleted;
            _context.Update<AssignedTasksChildModel>(AssignedTasksChild);
            return _context.SaveChanges() != 0;
        }

    }
}