using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace scrubby_webapi.Models.DTO
{
    public class UserDataDTO
    {
        
        public UserDTO? userInfo { get; set; }
        public List<DependentModel>? Children { get; set; }
        public List<CollectionsDTO>? Spaces { get; set; }


    }
}