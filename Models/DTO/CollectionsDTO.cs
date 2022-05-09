using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace scrubby_webapi.Models.DTO
{
    public class CollectionsDTO
    {
        public int Id { get; set; }
        public string? CollectionName { get; set; }
        public bool IsDeleted { get; set; }

        public List<SpacesDTO>? Rooms { get; set; }
        public List<SharedSpacesDTO>? SharedWith { get; set; }

    }
}