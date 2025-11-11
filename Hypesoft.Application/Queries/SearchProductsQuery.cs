using Hypesoft.Domain.Entities;
using MediatR;

namespace Hypesoft.Application.Queries
{
    public class SearchProductsQuery : IRequest<IEnumerable<Product>>
    {
        public string? name { get; set; }
        public string? category { get; set; }
    }
}