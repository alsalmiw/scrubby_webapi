using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using scrubby_webapi.Models;
using scrubby_webapi.Services.Context;

namespace scrubby_webapi.Services
{
    public class SelectedItemsInSpaceService
    {
        private readonly DataContext _context;
        public SelectedItemsInSpaceService(DataContext context)
        {
            _context = context; 
        }
        
        public IEnumerable<SelectedItemsInSpaceModel> GetSelectedTaskByUserId(int id)
        {
           return  _context.DataContext.Where(SelectedItemInSpaceService => item.Id == id);
        }
    }
}