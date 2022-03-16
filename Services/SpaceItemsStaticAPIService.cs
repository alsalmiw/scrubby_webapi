using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using scrubby_webapi.Services.Context;

namespace scrubby_webapi.Services
{
    public class SpaceItemsStaticAPIService
    {
        private readonly DataContext _context;
        public SpaceItemsStaticAPIService(DataContext context)
        {
            _context = context;
        }
    }
}