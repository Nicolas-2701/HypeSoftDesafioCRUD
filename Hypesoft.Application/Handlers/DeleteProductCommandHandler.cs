using Hypesoft.Application.Commands;
using Hypesoft.Application.Repository.ProductRepository;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Hypesoft.Application.Handlers
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, bool>
    {
        private readonly IProductRepository _productRepository;

        public DeleteProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<bool> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
        {
            var productToDelete = await _productRepository.GetByIdAsync(command.Id);

            if (productToDelete == null || productToDelete.IsDeleted)
            {
                return false;
            }

            productToDelete.IsDeleted = true;
            productToDelete.DateDeleted = DateTimeOffset.UtcNow;

            await _productRepository.UpdateAsync(productToDelete);

            return true;
        }
    }
}