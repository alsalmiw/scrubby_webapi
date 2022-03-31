using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace scrubby_webapi.Models
{
    public class CleaningProductsStaticAPIModel
    {
        public int Id { get; set; }
        public string? ProductName { get; set; }

        public string? Instructions { get; set; }
        public string? Warnings { get; set; }
        public string? TaskTags { get; set; }

        public CleaningProductsStaticAPIModel(){}

    }
}