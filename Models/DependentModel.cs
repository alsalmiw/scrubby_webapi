using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace scrubby_webapi.Models
{
    public class DependentModel
    {
        public int DependentId { get; set; }
        public int UserId { get; set; }
        public string? DependentName { get; set; }
        public int DependentAge { get; set; }
        public string? DependentPhoto { get; set; }
        public int DependentCoins { get; set; }
        public bool isDeleted { get; set; }

        public DependentModel(){}
    }
}