using Dotnet_Core_WebAPI_Demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dotnet_Core_WebAPI_Demo.Data.Interfaces
{
    public interface IDatingRepository
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<User> SaveAll(string id, User userInfo);
        Task<IEnumerable<User>> GetUsers();
        Task<User> GetUser(string id);
    }
}
