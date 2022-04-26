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
        public IEnumerable<SelectedTasksModel> GetSelectedTaskByUserId(int id)
        {
           return  _context.SelectedTasksInfo.Where(item => item.Id == id);
        }
        public bool UpdateSelectedTask(SelectedTasksModel selectedTaskToUpdate)
        {
            return false;
        }
        //
        public bool AddSelectedTask(List<SelectedTaskDTO> listOfSelectedItem)
        {
            List<SelectedTasksModel> newList = new List<SelectedTasksModel>();
            for (int i = 0; i < listOfSelectedItem.Count; i++)
            {
                 List<TasksInfoStaticAPIModel> newTasks = new List<TasksInfoStaticAPIModel>();
                newTasks = _context.TasksInfoStaticAPIInfo.Where(item => item.Tags.ToLower().Contains(listOfSelectedItem[i].Name.ToLower())).ToList();
                
                for (int j = 0; j < newTasks.Count; j++)
                {
                    SelectedTasksModel newTask = new SelectedTasksModel();
                        newTask.Id=0;
                        newTask.itemId = listOfSelectedItem[i].Id;
                        newTask.UserId = listOfSelectedItem[i].UserId;
                        newTask.taskId = newTasks[j].Id;
                        //product id
                        DateTime date = DateTime.Now;
                        newTask.DateCreated = date.ToString("MM/dd/yyyy") ;
                        newTask.isDeleted=false;
                        newTask.isArchived=false;
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
    }
}