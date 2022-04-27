using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace scrubby_webapi.Models
{
    public class SharedSpacesModel
    {
        public int Id { get; set; }
        public string? InvitedUsername { get; set; }
        public int CollectionId { get; set; }
        public bool? IsDeleted { get; set; }
        public bool? IsAccepted { get; set; }
        public SharedSpacesModel(){}
    }
}