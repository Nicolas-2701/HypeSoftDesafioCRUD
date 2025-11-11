using Hypesoft.Application.Queries;
using Hypesoft.Application.Repository.ProductRepository;
using Hypesoft.Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Hypesoft.Application.Handlers
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<Product>>
    {
        private readonly IProductRepository _productRepository;

        public GetAllProductsQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<Product>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var allProducts = await _productRepository.GetAllAsync();
            
            var activeProducts = allProducts.Where(p => p.IsDeleted == false);

            return activeProducts;
        }
    }
}