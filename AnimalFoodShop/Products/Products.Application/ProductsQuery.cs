using System.Collections.Generic;
using MediatR;
using Products.Domain;

namespace Products.Application
{
    public class ProductsQuery : IRequest<IEnumerable<Product>>
    {
        public ProductsQuery()
        {
        }
    }
}
