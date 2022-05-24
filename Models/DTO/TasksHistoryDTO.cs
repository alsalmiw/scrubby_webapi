using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace scrubby_webapi.Models.DTO
{
    public class TasksHistoryDTO
    {
        public int MemberId { get; set; }
        public string? Name { get; set; }
        public bool IsChild { get; set; }

        public int TaskId { get; set; }
        public string? TaskSpace { get; set; }
        public string? TaskRoom { get; set; }
        public string? TaskName { get; set; }
        public bool IsCompleted { get; set; }
        public string? DateScheduled { get; set; }
        public string? DateCompleted { get; set; }
        public bool IsRequestedApproval { get; set; }

    }
}