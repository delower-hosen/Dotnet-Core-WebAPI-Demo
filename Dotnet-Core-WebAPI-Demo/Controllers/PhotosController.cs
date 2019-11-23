using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Dotnet_Core_WebAPI_Demo.Data.Interfaces;
using Dotnet_Core_WebAPI_Demo.Dtos;
using Dotnet_Core_WebAPI_Demo.Helper;
using Dotnet_Core_WebAPI_Demo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Dotnet_Core_WebAPI_Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotosController : ControllerBase
    {
        private readonly IPhotoRepository _repo;
        private readonly IMapper _maper;

        public PhotosController(IPhotoRepository repo, IMapper maper)
        {
            _repo = repo;
            _maper = maper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPhotos(string id)
        {
            var photos = await _repo.GetPhotos(id);
            return Ok(photos);
        }
    }
}