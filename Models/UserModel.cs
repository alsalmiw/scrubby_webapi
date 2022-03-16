using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace scrubby_webapi.Models
{
    public class UserModel
    {
        public int Id {get; set;}
        public string? Username {get; set;}
        public string? Salt {get; set;}
        public string? Hash {get; set;}
         public int TrackerId { get; set; }
        //public int UserId { get; set; }
        public string? Photo { get; set; }
        public int Coins { get; set; }
        public UserModel(){}
    }
}