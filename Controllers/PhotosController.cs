using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using scrubby_webapi.Services;
using scrubby_webapi.Models;

namespace scrubby_webapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PhotosController : Controller
    {
      private readonly PhotosService _Service;
        public PhotosController(PhotosService dataFromPhotoService)
        {
            _Service = dataFromPhotoService;
        }


    [HttpPost("uploadingImage"), DisableRequestSizeLimit]

        public async Task<ActionResult> UploadImage()
        {
            IFormFile file = Request.Form.Files[0];
            if(file == null)
            {
                return BadRequest();
            }

            var result = await _Service.UploadImage(
                "scrubbystorage",
                file.OpenReadStream(),
                file.ContentType,
                file.FileName
            );
            var toReturn = result.AbsoluteUri;
            return Ok(new {path = toReturn});
        }

    }
}