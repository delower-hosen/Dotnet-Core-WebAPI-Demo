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
    public class DatingRepository : IDatingRepository
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

        public async Task<User> GetUser(string userId)
        {
            var userInfo = await _user.Find(user => user.Id == userId).FirstOrDefaultAsync();
            return userInfo;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            var users = await _user.Find(user => true).ToListAsync();
            return users;
        }

        public async Task<User> SaveAll(string userId, User userInfo)
        {
            var user = await _user.Find(user => user.Id == userId).FirstOrDefaultAsync();
            if (user != null)
            {
                if (userInfo.Introduction != null)
                {
                    user.Introduction = userInfo.Introduction;
                }
                if (userInfo.LookingFor != null)
                {
                    user.LookingFor = userInfo.LookingFor;
                }
                if (userInfo.Interests != null)
                {
                    user.Interests = userInfo.Interests;
                }
                if (userInfo.City != null)
                {
                    user.City = userInfo.City;
                }
                if (userInfo.Country != null)
                {
                    user.Country = userInfo.Country;
                }
                if (userInfo.ProfilePhoto != null)
                {
                    user.ProfilePhoto = userInfo.ProfilePhoto;
                }
                if(userInfo.LastActive != null)
                {
                    user.LastActive = userInfo.LastActive;
                }
            }
            _user.ReplaceOne(u => u.Id == userId, user);
            return user;
        }
    }
}
