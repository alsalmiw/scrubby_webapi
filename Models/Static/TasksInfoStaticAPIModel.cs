using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace scrubby_webapi.Models.Static
{
    public class TasksInfoStaticAPIModel
    {
         public int Id { get; set; }
         public string? Name { get; set; }
         public string? Description { get; set; }
        public string? Tags { get; set; }
         public string? Time { get; set; }
         public int coins { get; set; }

         public TasksInfoStaticAPIModel(){}
    }
}