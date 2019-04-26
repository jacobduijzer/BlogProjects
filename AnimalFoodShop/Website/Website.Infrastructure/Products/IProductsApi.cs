using System.Collections.Generic;
using System.Threading.Tasks;
using Refit;
using Website.Domain.Products;

namespace Website.Infrastructure.Products
{
    public interface IProductsApi
    {
        [Get("/products")]
        Task<IEnumerable<Product>> GetAllProducts();
    }
}
