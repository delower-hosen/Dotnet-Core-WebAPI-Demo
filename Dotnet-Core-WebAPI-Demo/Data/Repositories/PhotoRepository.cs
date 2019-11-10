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
    public class PhotoRepository : IPhotoRepository
    {
        private readonly IMongoCollection<Photo> _photo;
        public PhotoRepository(IDatabaseSetting settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _photo = database.GetCollection<Photo>("Photos");
        }

        public void Add<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }

        public void Delete<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Photo>> GetPhotos(string ChildEntityId)
        {
            var photos = await _photo.Find(p => p.Id == ChildEntityId).ToListAsync();
            return photos;
        }
    }
}
