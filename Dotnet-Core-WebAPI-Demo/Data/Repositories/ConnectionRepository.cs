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
    public class ConnectionRepository : IConnectionRepository
    {
        private readonly IMongoCollection<Connection> _connection;

        public ConnectionRepository(IDatabaseSetting settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _connection = database.GetCollection<Connection>("Connections");
        }
        public async Task<IEnumerable<Connection>> GetConnectionList(string ParentEntityId)
        {
            var connections = await _connection.Find(c => c.ParentEntityId == ParentEntityId).ToListAsync();
            return connections;
        }
    }
}
