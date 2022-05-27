using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace scrubby_webapi.Models.DTO
{
    public class ScoreBoardPointsDTO
    {
        public string? Name { get; set; }
        public int Points { get; set; }
        public bool IsChild { get; set; }
    }
}