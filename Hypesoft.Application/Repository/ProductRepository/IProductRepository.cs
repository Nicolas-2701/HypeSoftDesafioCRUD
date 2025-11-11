using Hypesoft.Application.Repository.ICommon;
using Hypesoft.Domain.Entities;

namespace Hypesoft.Application.Repository.ProductRepository
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        Task<IEnumerable<Product>> SearchProductsAsync(string? name, string? category);
        
        Task<IEnumerable<Product>> GetLowStockProductsAsync();
    }
}