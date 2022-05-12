using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace scrubby_webapi.Models.DTO
{
    public class UserDataDTO
    {
        
        public UserDTO? userInfo { get; set; }
        public List<DependentDTO>? Children { get; set; }
        public List<CollectionsDTO>? Spaces { get; set; }
        public InvitesDTO? Invitations { get; set; }
        public List <ScoreBoardPointsDTO>? ScoreBoard { get; set; }

        public List <ScheduleAssignedTasksDTO>? MyScheduledTasks { get; set; }



    }
}        