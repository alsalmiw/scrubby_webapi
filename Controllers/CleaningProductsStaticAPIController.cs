using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using scrubby_webapi.Services;

namespace scrubby_webapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CleaningProductsStaticAPIController : ControllerBase
    {

        private readonly CleaningProductsStaticAPIService _data;

        public CleaningProductsStaticAPIController(CleaningProductsStaticAPIService _dataFromService)
        {
            _data = _dataFromService;
        }
        
    }
}