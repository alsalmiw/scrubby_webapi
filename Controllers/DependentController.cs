using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using scrubby_webapi.Services;
using scrubby_webapi.Models;
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
    }
}