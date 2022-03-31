using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace scrubby_webapi.Models
{
    public class SpaceCollectionModel
    {
        public int Id { get; set; }
        public string? CollectionName { get; set; }
        public bool IsDeleted { get; set; }
        public int UserId { get; set; }
        public SpaceCollectionModel () {}
    }
}