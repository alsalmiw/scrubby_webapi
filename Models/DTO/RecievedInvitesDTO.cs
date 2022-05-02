using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace scrubby_webapi.Models.DTO
{
    public class RecievedInvitesDTO
    {
        public int Id { get; set; }
        public int InviterId { get; set; }
        public string? InviterUsername { get; set; }
        public string? InviterFullname { get; set; }
         public string? InviterPhoto { get; set; }
        public bool IsAccepted { get; set; }
        public bool IsDeleted { get; set; }

    }
}