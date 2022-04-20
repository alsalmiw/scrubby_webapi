using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using scrubby_webapi.Services.Context;
using scrubby_webapi.Models;
using scrubby_webapi.Models.Static;

namespace scrubby_webapi.Services
{
    public class SpaceItemsStaticAPIService
    {
        private readonly DataContext _context;
        public SpaceItemsStaticAPIService(DataContext context)
        {
            _context = context;
        }
        public IEnumerable<SpaceItemsStaticAPIModel> GetSpaceItemsStaticAPIByTags(string Tags)
        {
            return _context.SpaceItemsStaticAPIInfo.Where(item => item.Tags.Contains(Tags.ToLower()));
            
        }

        public IEnumerable<SpaceItemsStaticAPIModel>GetAllSpaceItemsStaticAPI()
        {
            return _context.SpaceItemsStaticAPIInfo;
        }
    }
}