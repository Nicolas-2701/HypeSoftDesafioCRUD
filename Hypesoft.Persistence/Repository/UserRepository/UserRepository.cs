using Hypesoft.Application.Repository.UserRepository;
using Hypesoft.Domain.Entities;
using Hypesoft.Persistence.Repository.Common;
using MongoDB.Driver;

namespace Hypesoft.Persistence.Repository.UserRepository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(IMongoDatabase database)
            : base(database, "Users") { }
    }
}
