using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using scrubby_webapi.Models;
using scrubby_webapi.Services.Context;

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
            return UpdateSelectedTask(selectedTaskToUpdate);
        }
    }
}