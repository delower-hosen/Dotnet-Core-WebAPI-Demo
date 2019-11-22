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
        private readonly IOptions<CloudinarySettings> _cloudinaryConfig;
        private Cloudinary _cloudinary;

        public PhotosController(IPhotoRepository repo, IMapper maper,
            IOptions<CloudinarySettings> cloudinaryConfig)
        {
            _repo = repo;
            _maper = maper;
            _cloudinaryConfig = cloudinaryConfig;

            Account acc = new Account(
                    _cloudinaryConfig.Value.CloudName,
                    _cloudinaryConfig.Value.ApiKey,
                    _cloudinaryConfig.Value.ApiSecret
                );
            _cloudinary = new Cloudinary(acc);
        }

        [HttpPost("{id}")]
        public IActionResult AddPhotoForUser(string id, PhotoForCreationDto photoForCreationDto)
        {
            // Todo: validate user

            var file = photoForCreationDto.File;
            var uploadResult = new ImageUploadResult();

            if (file.Length > 0)
            {
                using (var stream = file.OpenReadStream())
                {
                    var uploadParams = new ImageUploadParams()
                    {
                        File = new FileDescription(file.Name, stream),
                        Transformation = new Transformation()
                            .Width(500).Height(500).Crop("fill").Gravity("face")
                    };
                    uploadResult = _cloudinary.Upload(uploadParams);
                }
            }
            photoForCreationDto.Url = uploadResult.Uri.ToString();
            photoForCreationDto.PublicId = uploadResult.PublicId.ToString();

            var photo = _maper.Map<Photo>(photoForCreationDto);

            return Ok(photo);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPhotos(string id)
        {
            var photos = await _repo.GetPhotos(id);
            return Ok(photos);
        }
    }
}