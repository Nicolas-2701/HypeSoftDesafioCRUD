using Hypesoft.Domain.Entities;
using MediatR;

namespace Hypesoft.Application.Queries
{
    public class GetProductByIdQuery : IRequest<Product?>
    {
        public required string Id { get; set; }
    }
}