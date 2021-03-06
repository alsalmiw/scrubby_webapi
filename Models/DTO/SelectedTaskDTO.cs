using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace scrubby_webapi.Models.DTO
{
    public class SelectedTaskDTO
    {
                public int Id { get; set; } 
                public int UserId { get; set; }
                public int SpaceId { get; set; }
                public string? Description { get; set; }
                public string? Name { get; set; }
                public string? Tags { get; set; }
    }
}