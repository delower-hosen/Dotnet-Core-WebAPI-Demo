using Dotnet_Core_WebAPI_Demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dotnet_Core_WebAPI_Demo.Data.Interfaces
{
    public interface IConnectionRepository
    {
        Task<IEnumerable<Connection>> GetConnectionList(string ParentEntityId);
    }
}
