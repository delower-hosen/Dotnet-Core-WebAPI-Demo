using Dotnet_Core_WebAPI_Demo.Data.Interfaces;
using Dotnet_Core_WebAPI_Demo.DatabaseSettings;
using Dotnet_Core_WebAPI_Demo.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dotnet_Core_WebAPI_Demo.Data.Repositories
{
    public class DatingRepository: IDatingRepository
    {
        private readonly IMongoCollection<User> _user;
        public DatingRepository(IDatabaseSetting settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _user = database.GetCollection<User>("Users");
        }
        public void Add<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }

        public void Delete<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUser()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            var users = await _user.Find(user => true).ToListAsync();
            return users;
        }

        public Task<bool> SaveAll()
        {
            throw new NotImplementedException();
        }
    }
}
