using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace scrubby_webapi.Models.DTO
{
    public class InvitesDTO
    {
        public List<SentInvitesDTO>? SentInvites { get; set; }
        public List<RecievedInvitesDTO>? RecievedInvites { get; set; }

    }
}