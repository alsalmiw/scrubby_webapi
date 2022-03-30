using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace scrubby_webapi.Services
{
    public class AssignedTasksChildService
    {
         private readonly DataContext _context;
        public AssignedTasksChildService(DataContext context)
        {
            _context = context;
        }
    }
}