using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dotnet_Core_WebAPI_Demo.Data.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Dotnet_Core_WebAPI_Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotosController : ControllerBase
    {
        private readonly IPhotoRepository _repo;
        private readonly IConfiguration _config;
        public PhotosController(IPhotoRepository repo, IConfiguration config)
        {
            _repo = repo;
            _config = config;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPhotos(string id)
        {
            var photos = await _repo.GetPhotos(id);
            return Ok(photos);
        }
    }
}