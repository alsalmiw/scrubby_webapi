using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace scrubby_webapi.Services
{
    public class SelectedItemInSpaceService
    {
        private readonly DataContext _context;
        public DependentService(DataContext context)
        {
            _context = context; 
        }
        
        public IEnumerable<SelectedTasksModel> GetSelectedTaskByUserId(int id)
        {
           return  _context.DataContext.Where(SelectedItemInSpaceService => item.Id == id);
        }
    }
}