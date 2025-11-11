using MediatR;

namespace Hypesoft.Application.Commands
{
    public class DeleteProductCommand : IRequest<bool>
    {
        public required string Id { get; set; }
    }
}