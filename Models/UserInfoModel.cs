using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace scrubby_webapi.Models
{
    public class UserInfoModel
    {
        public int TrackerId { get; set; }
        public int UserId { get; set; }
        public string? Photo { get; set; }
        public int Coins { get; set; }

        

        //Removing tasks completed

        public UserInfoModel() {}

        
        
    }
}