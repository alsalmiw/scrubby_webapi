using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using scrubby_webapi.Services.Context;
using scrubby_webapi.Models.Static;
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
            return _context.CleaningProductsStaticAPIInfo.SingleOrDefault(item => item.Id == Id);
        }

        public IEnumerable<CleaningProductsStaticAPIModel> GetCleaningProductsAPIByTags(string Tags)
        {
            
            return _context.CleaningProductsStaticAPIInfo.Where(item => item.TaskTags.Contains(Tags.ToLower()));
        }

        public IEnumerable<CleaningProductsStaticAPIModel> GetTasksInfoStaticAPIByTags(string Tags)
        {
            return _context.CleaningProductsStaticAPIInfo.Where(item => item.TaskTags.Contains(Tags.ToLower()));
        }





    }
}