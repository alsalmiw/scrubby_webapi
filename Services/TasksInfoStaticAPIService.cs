using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace scrubby_webapi.Services.Context
{
    public class TasksInfoStaticAPIService
    {
        private readonly DataContext _context;
        public TasksInfoStaticAPIService(DataContext context)
        {
            _context = context;
        }
    }
}