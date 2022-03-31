using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace scrubby_webapi.Models
{
    public class AssignedTasksChildModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int SelectedTasksId { get; set; }
        public string? DateCreated { get; set; }
        public string? DateCompleted { get; set; }
        public bool IsDeleted { get; set; }
        public int Repeat { get; set; }
        public AssignedTasksChildModel (){}
    }
}