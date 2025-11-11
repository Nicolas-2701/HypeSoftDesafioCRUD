using Hypesoft.Domain.Entities;
using MediatR;

namespace Hypesoft.Application.Commands
{
    public class UpdateProductCommand : IRequest<Product?>
    {
        public required string Id { get; set; } 
        public required string name { get; set; }
        public string? desc { get; set; }
        public required string category { get; set; }
        public int price { get; set; }
        public int amout { get; set; }
    }
}