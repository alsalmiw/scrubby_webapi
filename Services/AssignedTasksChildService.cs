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
            _context.Add(AssignedTasksChildToCreate);
            return _context.SaveChanges() !=0;
        }

        public bool AddChildAssignedTasks(List<AssignedTasksChildModel> listOfAssignedTasks)
        {
            bool result = false;
            for(int i = 0; i < listOfAssignedTasks.Count; i++){

                AssignedTasksChildModel foundTask = _context.AssignedTasksChildInfo.SingleOrDefault(task => task.ChildId == listOfAssignedTasks[i].ChildId && task.SpaceId == listOfAssignedTasks[i].SpaceId && task.AssignedTaskId == listOfAssignedTasks[i].AssignedTaskId && task.DateCreated== listOfAssignedTasks[i].DateCreated && task.IsDeleted==false);
                if(foundTask == null)
                {
                     _context.Add(listOfAssignedTasks[i]);
                    result = _context.SaveChanges() !=0;
                }
                else{
                    foundTask.IsDeleted = true;
                    _context.Update<AssignedTasksChildModel>(foundTask);
                    result = _context.SaveChanges() !=0;
                }
            }
           
            return result;
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

            AssignedTasksChild.IsDeleted = !AssignedTasksChild.IsDeleted;
            _context.Update<AssignedTasksChildModel>(AssignedTasksChild);
            return _context.SaveChanges() != 0;
        }

         public bool SubmitTaskChildApproval(int taskId)
        {
             AssignedTasksChildModel findTask = _context.AssignedTasksChildInfo.SingleOrDefault(item => item.Id == taskId);
                bool result = false;
             if(findTask != null){
                findTask.IsRequestedApproval = true;
               _context.Update<AssignedTasksChildModel>(findTask);
               result =_context.SaveChanges() != 0;
               }
               return  result;
        }

    
        public bool ApproveTaskForCompletionChild(int taskId)
        {
              AssignedTasksChildModel findTask = _context.AssignedTasksChildInfo.SingleOrDefault(item => item.Id == taskId);
                bool result = false;
             if(findTask != null){
                DateTime thisDay = DateTime.Today;
                findTask.IsCompleted = true;
                findTask.DateCompleted = thisDay.ToString("d");
               _context.Update<AssignedTasksChildModel>(findTask);
               result =_context.SaveChanges() != 0;
               }
               return  result;
        }

    }
}