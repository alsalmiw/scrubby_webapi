using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using scrubby_webapi.Models.Static;
using scrubby_webapi.Services.Context;

namespace scrubby_webapi.Services.Context
{
    public class TasksInfoStaticAPIService
    {
        private readonly DataContext _context;
        public TasksInfoStaticAPIService(DataContext context)
        {
            _context = context;
        }
        public TasksInfoStaticAPIModel GetTasksInfoStaticAPIById(int Id)
        {
            return _context.TasksInfoStaticInfo.SingleOrDefault(item => item.Id == Id);
        }
        public List<TasksInfoStaticAPIModel> GetTasksInfoStaticAPIByTags(string Tags)
        {
            
            return _context.TasksInfoStaticInfo.SingleOrDefault(item => item.Tags.Contains().toLower() == Tags.ToLower());
        }

    }
}