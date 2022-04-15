using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace scrubby_webapi.Models
{
    public class AssignedTasksUsersModel
    {
        //Primary Key: ID

        //Foreign Key: UserIdTasked, UserIdTasked, UserIdOwner
        
        public int Id { get; set; }     
        
        public int UserIdTasked { get; set; }  
        
        public int UserIdOwner { get; set; }   
        
        public int SelectedTasksId { get; set; } 
        public string? DateCreated { get; set; }
        public string? DateCompleted { get; set; }
        public int Repeat { get; set; }

        public AssignedTasksUsersModel(){}
        
    }
}