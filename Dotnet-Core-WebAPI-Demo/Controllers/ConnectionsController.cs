using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Dotnet_Core_WebAPI_Demo.Data.Interfaces;
using Dotnet_Core_WebAPI_Demo.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Dotnet_Core_WebAPI_Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConnectionsController : ControllerBase
    {
        private readonly IConnectionRepository _repo;
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;

        public ConnectionsController(IConnectionRepository repo, IConfiguration config, IMapper mapper)
        {
            _repo = repo;
            _config = config;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetConnectionList(string id)
        {
            var connections = await _repo.GetConnectionList(id);
            var connectionsToReturn = _mapper.Map<IEnumerable<ConnectionForListDto>>(connections);
            return Ok(connectionsToReturn);
        }
    }
}