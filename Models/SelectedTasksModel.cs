using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace scrubby_webapi.Models
{
    public class SelectedTasksModel
    {  
        public int Id { get; set; } 
        public int ItemId { get; set; }
        public int UserId { get; set; }
        public int TaskId { get; set; }
        public int ProductId { get; set; }
        public string? DateCreated { get; set; }
        public string? DateCompleted { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsArchived { get; set; }
        public SelectedTasksModel(){}
    }
}