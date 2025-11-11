using Hypesoft.Application.Repository.ICommon;
using Hypesoft.Domain.Common;
using MongoDB.Driver;

namespace Hypesoft.Persistence.Repository.Common
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseModel
    {
        protected readonly IMongoCollection<T> _collection;

        public BaseRepository(IMongoDatabase database, string collectionName)
        {
            _collection = database.GetCollection<T>(collectionName);
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            var result = await _collection.Find(_ => true).ToListAsync();
            return result.AsReadOnly();
        }

        public async Task<T> GetByIdAsync(string id)
        {
            return await _collection.Find(entity => entity.Id == id).FirstOrDefaultAsync();
        }

        public async Task AddAsync(T entity)
        {
            entity.DateCreated = DateTimeOffset.UtcNow;
            await _collection.InsertOneAsync(entity);
        }

        public async Task UpdateAsync(T entity)
        {
            entity.DateUpdated = DateTimeOffset.UtcNow;
            var filter = Builders<T>.Filter.Eq(e => e.Id, entity.Id);
            await _collection.ReplaceOneAsync(filter, entity);
        }

        public async Task DeleteAsync(T entity)
        {
            var filter = Builders<T>.Filter.Eq(e => e.Id, entity.Id);
            await _collection.DeleteOneAsync(filter);
        }
    }
}
