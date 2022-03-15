using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace scrubby_webapi.Models.DTO
{
    public class PasswordDTO
    {
        public string? Salt  { get; set; }
        public string? Hash { get; set; }
    }
}