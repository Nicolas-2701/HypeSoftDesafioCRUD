using MediatR;
using Hypesoft.Application.Commands;
using Hypesoft.Domain.Entities;
using Hypesoft.Application.Repository.ProductRepository;

namespace Hypesoft.Application.Handlers
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Product>
    {
        private readonly IProductRepository _productRepository;

        public CreateProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Product> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            var newProduct = new Product
            {
                name = command.name,
                desc = command.desc,
                category = command.category,
                price = command.price,
                amout = command.amout
            };

            await _productRepository.AddAsync(newProduct);

            return newProduct;
        }
    }
}