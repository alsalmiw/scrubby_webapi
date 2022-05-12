using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using scrubby_webapi.Services;
using scrubby_webapi.Models;


namespace scrubby_webapi.Controllers
{
    public class DefaultCollectionController
    {
        private readonly DefaultCollectionService _data;
        public DefaultCollectionController (DefaultCollectionService dataFromDefaultCollectionService)
        {
            _data = dataFromDefaultCollectionService;
        }
    }
}