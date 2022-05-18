using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace scrubby_webapi.Models
{
    public class DefaultCollectionDependentModel
    {
        public int Id { get; set; }
        public int ChildId { get; set; } 
        public int CollectionId { get; set; }   
        public bool IsDefault { get; set; }

        public DefaultCollectionDependentModel(){}
    }
}