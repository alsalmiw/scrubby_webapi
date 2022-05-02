using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace scrubby_webapi.Models.DTO
{
    public class SentInvitesDTO
    {
        public int Id { get; set; }
        public int InvitedId { get; set; }
        public string? InvitedUsername { get; set; }
        public string? InvitedFullname { get; set; }
         public string? InvitedPhoto { get; set; }
        public bool IsAccepted { get; set; }
        public bool IsDeleted { get; set; }

    }
}