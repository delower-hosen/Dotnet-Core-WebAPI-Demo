using AutoMapper;
using Dotnet_Core_WebAPI_Demo.Dtos;
using Dotnet_Core_WebAPI_Demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dotnet_Core_WebAPI_Demo.Helper
{
    public class AutoMapping: Profile
    {
        public AutoMapping()
        {
            CreateMap<User, UserForListDto>(); // means you want to map from User to UserForListDtor
            CreateMap<Connection, ConnectionForListDto>();
        }
    }
}
