using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using scrubby_webapi.Services.Context;
using scrubby_webapi.Models;

namespace scrubby_webapi.Services
{
    public class CleaningProductsStaticAPIService
    {
        private readonly DataContext _context;
        public CleaningProductsStaticAPIService(DataContext context)
        {
            _context = context;
        }

        public CleaningProductsStaticAPIModel GetAllCleaningProductsById(int Id)
        {
            return _context.CleaningProductsStaticAPIInfo.SingleOrDefault(item => item.Id == ID);
        }

        public List<CleaningProductsStaticAPIModel> GetCleaningProductsAPIByTags(string Tags)
        {
            
            return _context.CleaningProductsStaticAPIInfo.SingleOrDefault(item => item.Tags.Contains().toLower() == Tags.ToLower());
        }





    }
}