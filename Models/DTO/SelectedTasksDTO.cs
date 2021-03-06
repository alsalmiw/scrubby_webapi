using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using scrubby_webapi.Models.Static;

namespace scrubby_webapi.Models.DTO
{
    public class SelectedTasksDTO
    {
        public int Id { get; set; } 
        public string? DateScheduled { get; set; }
        public string? DateCompleted { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsCompleted { get; set; }
        public bool IsArchived { get; set; }
        public bool IsRequestedApproval { get; set; }

        public TasksInfoStaticAPIModel? Task { get; set; }
        public SpaceItemsStaticAPIModel? Item { get; set; }
    }
}