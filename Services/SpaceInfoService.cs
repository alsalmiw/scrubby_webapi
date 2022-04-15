using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using scrubby_webapi.Models;
using scrubby_webapi.Services.Context;

namespace scrubby_webapi.Services
{
    public class SpaceInfoService
    {
        private readonly DataContext _context;

        public SpaceInfoService(DataContext context)
        {
            _context = context;
        }

        public bool AddNewSpace(SpaceInfoModel newSpace)
        {
            _context.Add(newSpace);
            return _context.SaveChanges() != 0;
        }
        
        public IEnumerable<SpaceInfoModel> GetAllSpaces()
        {
            return _context.SpaceInfo;
        }

    }
}