using Hypesoft.Application.Commands;
using Hypesoft.Application.Repository.ProductRepository;
using Hypesoft.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Hypesoft.Application.Handlers
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Product?>
    {
        private readonly IProductRepository _productRepository;

        public UpdateProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Product?> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
        {
            var productToUpdate = await _productRepository.GetByIdAsync(command.Id);

            if (productToUpdate == null || productToUpdate.IsDeleted)
            {
                return null;
            }

            productToUpdate.name = command.name;
            productToUpdate.desc = command.desc;
            productToUpdate.category = command.category;
            productToUpdate.price = command.price;
            productToUpdate.amout = command.amout;
            productToUpdate.DateUpdated = DateTimeOffset.UtcNow; 

            await _productRepository.UpdateAsync(productToUpdate);

            return productToUpdate;
        }
    }
}