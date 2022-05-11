using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace scrubby_webapi.Models.DTO
{
    public class SpacesDTO
    {
         public int Id { get; set; }
        public string? SpaceName { get; set; }
        public string? SpaceCategory { get; set; }

        public List <SelectedTasksDTO>? Tasks { get; set; }
        public List <AssignedTasksDTO>? TasksAssigned { get; set; }
    }
}