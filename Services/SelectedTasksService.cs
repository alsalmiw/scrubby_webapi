using System;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using scrubby_webapi.Models;
using scrubby_webapi.Models.Static;
using scrubby_webapi.Models.DTO;
using scrubby_webapi.Services.Context;
using System.Collections;

namespace scrubby_webapi.Services
{
    public class SelectedTasksService
    {
        private readonly DataContext _context;
        public SelectedTasksService(DataContext context)
        {
            _context = context; 
        }
        public IEnumerable<SelectedTasksModel> GetSelectedTaskById(int id)
        {
           return  _context.SelectedTasksInfo.Where(item => item.Id == id);
        }

         public IEnumerable<SelectedTasksModel> GetSelectedTaskByUserId(int userId)
        {
           return  _context.SelectedTasksInfo.Where(item => item.UserId == userId);
        }
        public bool UpdateSelectedTask(SelectedTasksModel selectedTaskToUpdate)
        {
            return false;
        }

        public IEnumerable<SelectedTasksModel> GetAllSelectedTasks()
        {
           return  _context.SelectedTasksInfo;
        }
        //
        public bool AddSelectedTask(List<SelectedTaskDTO> listOfSelectedItem)
        {
            List<SelectedTasksModel> newList = new List<SelectedTasksModel>();
            for (int i = 0; i < listOfSelectedItem.Count; i++)
            {
                List<TasksInfoStaticAPIModel> newTasks = new List<TasksInfoStaticAPIModel>();
                newTasks = _context.TasksInfoStaticAPIInfo.Where(item => item.Tags.ToLower().Contains(listOfSelectedItem[i].Name.ToLower())).ToList();
                Console.WriteLine(newTasks);
                for (int j = 0; j < newTasks.Count; j++)
                {
                    SelectedTasksModel newTask = new SelectedTasksModel();
                        newTask.Id=0;
                        newTask.ItemId = listOfSelectedItem[i].Id;
                        newTask.UserId = listOfSelectedItem[i].UserId;
                        newTask.TaskId = newTasks[j].Id;
                        //product id
                        DateTime date = DateTime.Now;
                        newTask.DateCreated = date.ToString("MM/dd/yyyy") ;
                        newTask.IsDeleted=false;
                        newTask.IsArchived=false;
                        newList.Add(newTask);
                }
            }
            bool result = false;
            for (int k = 0; k < newList.Count; k++)
            {
                _context.Add(newList[k]);
                result = _context.SaveChanges()!=0;
            }
            //check if result is false to then break out
            //if failed need to get rid of duplicates.
            return result;


        }

         public IEnumerable<TasksInfoStaticAPIModel> getTasks (string? name)
        {
         
           List<TasksInfoStaticAPIModel> newTasks = new List<TasksInfoStaticAPIModel>();

           
                
                newTasks = _context.TasksInfoStaticAPIInfo.Where(item => item.Tags.ToLower().Contains(name.ToLower())).ToList();
              
            return newTasks;
        }

         public List<TasksInfoStaticAPIModel> getTasksByUserID(int userID)
        {
            List <SelectedTasksModel> allTasksByUser = GetSelectedTaskByUserId(userID).ToList();
            List<TasksInfoStaticAPIModel> SelectedTasks = new List<TasksInfoStaticAPIModel>();

            for (int i = 0; i < allTasksByUser.Count; i++)
            {
                TasksInfoStaticAPIModel findTask = _context.TasksInfoStaticAPIInfo.SingleOrDefault(task => task.Id == allTasksByUser[i].TaskId);
                if(findTask != null)
                {
                    SelectedTasks.Add(findTask);
                }
            }

            return SelectedTasks;

        }

    }
}