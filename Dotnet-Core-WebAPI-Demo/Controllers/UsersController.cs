using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Dotnet_Core_WebAPI_Demo.Data.Interfaces;
using Dotnet_Core_WebAPI_Demo.Dtos;
using Dotnet_Core_WebAPI_Demo.Helper;
using Dotnet_Core_WebAPI_Demo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Dotnet_Core_WebAPI_Demo.Controllers
{
    //[ServiceFilter(typeof(LogUserActivity))]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IDatingRepository _repo;
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;

        public UsersController(IDatingRepository repo, IConfiguration config, IMapper mapper)
        {
            _repo = repo;
            _config = config;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _repo.GetUsers();
            var usersToReturn = _mapper.Map<IEnumerable<UserForListDto>>(users);
            return Ok(usersToReturn);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetConnectionList(string id)
        {
            var userInfo = await _repo.GetUser(id);
            return Ok(userInfo);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUsers(string id, User userInfo)
        {
            var user = await _repo.SaveAll(id, userInfo);
            if(user == null)
            {
                return NoContent();
            }
            return Ok(user);
        }
    }
}