using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace scrubby_webapi.Models
{
    public class SelectedTasksModel
    {  
        public int Id { get; set; } 
        public int itemId { get; set; }
        public int UserId { get; set; }
        public int taskId { get; set; }
        public int productId { get; set; }
        public string? DateCreated { get; set; }
        public string? DateCompleted { get; set; }
        public bool isDeleted { get; set; }
        public bool isArchived { get; set; }
        public SelectedTasksModel(){}
    }
}