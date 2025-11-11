using Hypesoft.Domain.Entities;
using Hypesoft.Persistence.Settings;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;

namespace Hypesoft.Persistence.Context
{
    public class DotNetContext : DbContext
    {

        private readonly IMongoDatabase _database;

        public DotNetContext(MongoSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            _database = client.GetDatabase(settings.DatabaseName);
        }

        public IMongoCollection<User> Users => _database.GetCollection<User>("Users");

    }
}
