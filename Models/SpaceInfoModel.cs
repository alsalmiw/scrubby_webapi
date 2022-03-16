using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace scrubby_webapi.Models
{
    public class SpaceInfoModel
    {
        public int SpaceId { get; set; }
        public string? SpaceName { get; set; }
        public string? SpaceCategory { get; set; }
        public int UserId { get; set; }
        public SpaceInfoModel(){}
    }
}