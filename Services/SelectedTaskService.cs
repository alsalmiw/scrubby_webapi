using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using scrubby_webapi.Models;

namespace scrubby_webapi.Services
{
    public class SelectedTaskService
    {
        private readonly DataContext _context;
        public DependentService(DataContext context)
        {
            _context = context; 
        }
        public IEnumerable<SelectedTasksModel> GetSelectedTaskByUserId(int id)
        {
           return  _context.SelectedTasksInfo.Where(item => item.Id == id);
        }
        public bool UpdateSelectedTask(SelectedTaskModel selectedTaskToUpdate)
        {
            return UpdateSelectedTask(selectedTaskToUpdate);
        }
    }
}