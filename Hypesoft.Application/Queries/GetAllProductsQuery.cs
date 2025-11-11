using Hypesoft.Domain.Entities;
using MediatR;
using System.Collections.Generic;

namespace Hypesoft.Application.Queries
{
    public class GetAllProductsQuery : IRequest<IEnumerable<Product>>
    {

    }
}