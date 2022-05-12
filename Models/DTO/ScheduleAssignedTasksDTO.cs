using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using scrubby_webapi.Models.Static;


namespace scrubby_webapi.Models.DTO
{
    public class ScheduleAssignedTasksDTO
    {
        public int Id { get; set; }  
        public int SpaceId { get; set; }   
        public string? DateCreated { get; set; }
        public string? DateCompleted { get; set; }

        public bool IsCompleted { get; set; }

        public TasksInfoStaticAPIModel? Task { get; set; }
        public SpaceItemsStaticAPIModel? Item { get; set; }


    }
}