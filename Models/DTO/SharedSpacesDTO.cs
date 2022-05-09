using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace scrubby_webapi.Models.DTO
{
    public class SharedSpacesDTO
    {
        public int Id { get; set; }
        public int InvitedId { get; set; }
        public string? InvitedUsername { get; set; }
        public string? InvitedName { get; set; }


    }
}