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
        public bool UpdateAssignedTasksChildByIdAndDateCom(int AssignedTaskId, string? DateCompleted)
        {
            bool result =false;
            AssignedTasksChildModel AssignedTasks = GetAssignedTasksChildById(AssignedTaskId);
            if(AssignedTasks != null)
            {
                AssignedTasks.DateCompleted = DateCompleted;
                _context.Update<AssignedTasksChildModel>(AssignedTasks);
                result = _context.SaveChanges()!=0;
            }
            return result;
        }
        //update repeat
        public bool UpdateRepeatAssignedTasksChildByIdAndRepeat(int AssignedTaskId, int Repeat)
        {
            bool result =false;
            AssignedTasksChildModel AssignedTasks = GetAssignedTasksChildById(AssignedTaskId);
            if(AssignedTasks != null)
            {
                AssignedTasks.Repeat = Repeat;
                _context.Update<AssignedTasksChildModel>(AssignedTasks);
                result = _context.SaveChanges()!=0;
            }
            return result;
        }
        public AssignedTasksChildModel GetAssignedTasksChildById(int AssignedTaskId)
        {
            return _context.AssignedTasksChildInfo.SingleOrDefault(item => item.Id == AssignedTaskId);
        }
        public IEnumerable<AssignedTasksChildModel> GetAssignedTasksChildByUserId(int UserId)
        {
            return _context.AssignedTasksChildInfo.Where(item => item.Id == UserId);
        }


        public bool DeletedAssignedTasksChildById(int AssignedTaskId)
        {
            AssignedTasksChildModel AssignedTasksChild = GetAssignedTasksChildById(AssignedTaskId);

            AssignedTasksChild.IsDeleted = !AssignedTasksChild.IsDeletedIsDeleted;
            _context.Update<AssignedTasksChildModel>(AssignedTasksChild);
            return _context.SaveChanges() != 0;
        }

    }
}