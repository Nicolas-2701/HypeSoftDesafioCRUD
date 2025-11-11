using Hypesoft.Application.Queries;
using Hypesoft.Application.Repository.ProductRepository;
using Hypesoft.Domain.Entities;
using MediatR;

namespace Hypesoft.Application.Handlers
{
    public class SearchProductsQueryHandler : IRequestHandler<SearchProductsQuery, IEnumerable<Product>>
    {
        private readonly IProductRepository _productRepository;

        public SearchProductsQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<Product>> Handle(SearchProductsQuery request, CancellationToken cancellationToken)
        {
            return await _productRepository.SearchProductsAsync(request.name, request.category);
        }
    }
}