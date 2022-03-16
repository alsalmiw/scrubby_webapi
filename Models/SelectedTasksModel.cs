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
        public int DateCreated { get; set; }
        public int DateCompleted { get; set; }
        public int Repeat { get; set; }
        public SelectedTasksModel(){}
    }
}