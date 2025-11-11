using Hypesoft.Application.Queries;
using Hypesoft.Application.Repository.ProductRepository;
using Hypesoft.Domain.Entities;
using MediatR;

namespace Hypesoft.Application.Handlers
{
    public class GetLowStockProductsQueryHandler : IRequestHandler<GetLowStockProductsQuery, IEnumerable<Product>>
    {
        private readonly IProductRepository _productRepository;

        public GetLowStockProductsQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<Product>> Handle(GetLowStockProductsQuery request, CancellationToken cancellationToken)
        {
            return await _productRepository.GetLowStockProductsAsync();
        }
    }
}