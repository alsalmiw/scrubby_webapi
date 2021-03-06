using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using scrubby_webapi.Services;
using scrubby_webapi.Models;
using scrubby_webapi.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace scrubby_webapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DependentController : ControllerBase
    {
        private readonly DependentService _data;
        public DependentController(DependentService dataFromDependentService)
        {
            _data = dataFromDependentService;
        }
        [HttpPost("AddDependent")]
        public bool AddDependent (DependentModel newDependent)
        {
            return _data.AddDependent(newDependent);
        }

        
        [HttpPost("UpdateDependent")]
        public bool UpdateDependent (DependentModel dependentUpdate)
        {
            return _data.UpdateDependent(dependentUpdate);
        }

        [HttpGet("GetDependantByUserId/{userId}")]
        public IEnumerable<DependentModel> GetDependantByUserId (int userId)
        {
            return _data.GetDependantByUserId(userId);  
        }

        [HttpPost("NewCoinAmount")]
        public DependentModel NewCoinAmount(DependentModel newAmount)
        {
            return _data.NewCoinAmount(newAmount);
        }
        [HttpPost("UpdatePassCode")]
        public DependentModel UpdatedChildPassCode(DependentModel passCodeUpdate)
        {
            return _data.UpdatedChildPassCode(passCodeUpdate);
        }



          [HttpGet("GetDependantDTOByChildId/{childId}")]
        public DependentDTO GetDependantDTOByChildId (int childId)
        {
            return _data.GetDependantDTOByChildId(childId);  
        }

         [HttpGet("GetDependantsDTOByUserId/{userId}")]
        public List< DependentDTO> GetDependantsDTOByUserId (int userId)
        {
            return _data.GetDependantsDTOByUserId(userId);  
        }

        [HttpGet("GetDependantsDTOByUsername/{username}")]
        public List< DependentDTO> GetDependantsDTOByUsername(string? username)
        {
            return _data.GetDependantsDTOByUsername(username);  
        }

          [HttpGet("GetDependantByChildId/{childId}")]
        public DependentModel GetDependantByChildId (int childId)
        {
            return _data.GetDependantByChildId(childId);  
        }

        [HttpPost("UpdateDependentCoinsAndPoints")]
        public DependentModel UpdateDependentCoinsAndPoints (DependentModel newPointsAndCoins)
        {
            return _data.UpdateDependentCoinsAndPoints(newPointsAndCoins);
        }

        [HttpPost("ChangeChildName")]
        public bool ChangeChildName (ChildNameDTO NewName)
        {
            return _data.ChangeChildName(NewName);
        }

        [HttpPost("ChangeDependentAvatarImage")]
        public bool ChangeDependentAvatarImage(ImageDTO avatar)
        {
            return _data.ChangeDependentAvatarImage(avatar);
        }

           [HttpPost("DeleteChildByChildID/{id}")]
        public bool DeleteChildByChildID(int id)
        {
            return _data.DeleteChildByChildID(id);
        }
         
         

          

           






            

             


             
    }
}