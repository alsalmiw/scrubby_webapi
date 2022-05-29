using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace scrubby_webapi.Models.DTO
{
    public class DefaultOptionsDTO
    {
         public int Id { get; set; }
        public string? CollectionName { get; set; }

        public List<SpaceInfoModel>? Rooms { get; set; }
    }
}