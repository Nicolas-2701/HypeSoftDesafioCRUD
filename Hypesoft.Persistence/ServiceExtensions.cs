using Hypesoft.Application.Repository.UserRepository;
using Hypesoft.Persistence.Repository.UserRepository;
using Hypesoft.Persistence.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace Hypesoft.Persistence
{
    public static class ServiceExtensions
    {
        public static void ConfigurePersistence(this IServiceCollection services, IConfiguration configuration)
        {
            var section = configuration.GetSection("MongoDB");

            var mongoConfig = section.Get<MongoSettings>();
            var mongoClient = new MongoClient(mongoConfig.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(mongoConfig.DatabaseName);

            services.AddSingleton(mongoDatabase);
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
