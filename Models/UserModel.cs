using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace scrubby_webapi.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string? Username { get; set; }
        public string? Salt { get; set; }
        public string? Hash { get; set; }
        public string? Photo { get; set; }
        public int Coins { get; set; }
        public bool IsDeleted { get; set; }
        public string? Name { get; set; }
        public int Points { get; set; }
        public bool IsChildFree { get; set; }
        public UserModel() { }
    }
}