using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace scrubby_webapi.Models
{
    public class SpaceInfoModel
    {
        public int Id { get; set; }
        public string? SpaceName { get; set; }
        public string? SpaceCategory { get; set; }
        public int CollectionId { get; set; }
        public SpaceInfoModel(){}
    }
}