using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace scrubby_webapi.Models
{
    public class SelectedTasksModel
    {  
        public int Id { get; set; } 
        public int taskAndProductId { get; set; }
        public string? DateCreated { get; set; }
        public string? DateCompleted { get; set; }
        public int Repeat { get; set; }
        public SelectedTasksModel(){}
    }
}