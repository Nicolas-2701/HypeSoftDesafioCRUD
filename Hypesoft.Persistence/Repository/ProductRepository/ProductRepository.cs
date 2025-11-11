using Hypesoft.Application.Repository.ProductRepository;
using Hypesoft.Domain.Entities;
using Hypesoft.Persistence.Repository.Common;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Hypesoft.Persistence.Repository.ProductRepository
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(IMongoDatabase database)
            : base(database, "Products") { }

        public async Task<IEnumerable<Product>> SearchProductsAsync(string? name, string? category)
        {
            var filterBuilder = Builders<Product>.Filter;
            var filter = filterBuilder.Eq(p => p.IsDeleted, false);

            if (!string.IsNullOrWhiteSpace(name))
            {
                filter &= filterBuilder.Regex(p => p.name, new BsonRegularExpression(name, "i"));
            }

            if (!string.IsNullOrWhiteSpace(category))
            {
                filter &= filterBuilder.Regex(p => p.category, new BsonRegularExpression(category, "i"));
            }

            return await _collection.Find(filter).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetLowStockProductsAsync()
        {
            var filterBuilder = Builders<Product>.Filter;
            var filter = filterBuilder.Eq(p => p.IsDeleted, false);
            filter &= filterBuilder.Lt(p => p.amout, 10);

            return await _collection.Find(filter).ToListAsync();
        }
    }
}