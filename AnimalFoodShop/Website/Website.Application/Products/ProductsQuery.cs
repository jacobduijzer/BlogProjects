using System.Collections.Generic;
using MediatR;
using Website.Domain.Products;

namespace Website.Application.Products
{
    public class ProductsQuery : IRequest<IEnumerable<Product>>
    {
        public ProductsQuery()
        {
        }
    }
}
