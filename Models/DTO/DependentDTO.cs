using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace scrubby_webapi.Models.DTO
{
    public class DependentDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string? DependentName { get; set; }
        public int DependentAge { get; set; }
        public string? DependentPhoto { get; set; }
        public int DependentCoins { get; set; }
        public int DependentPoints { get; set; }
        public int DependentPassCode { get; set; }
        
        public List <ScheduleCollectionsDTO>? ScheduledTasks { get; set; }
    }
}