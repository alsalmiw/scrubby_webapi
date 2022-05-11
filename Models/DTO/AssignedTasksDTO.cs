using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace scrubby_webapi.Models.DTO
{
    public class AssignedTasksDTO
    {
        public int Id { get; set; }
       
        public int UserId { get; set; }
        public string? Name { get; set; }
        public bool IsChild { get; set; }
        public int AssignedTaskId { get; set; } 
        public string? DateScheduled { get; set; }
        public string? DateCompleted { get; set; }

        public bool IsCompleted { get; set; }
        


    }
}