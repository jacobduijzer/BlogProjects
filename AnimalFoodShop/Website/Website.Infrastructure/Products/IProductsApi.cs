using System.Collections.Generic;
using System.Threading.Tasks;
using Refit;

namespace Website.Infrastructure.Products
{
    public interface IProductsApi
    {
        [Get("/products")]
        Task<IEnumerable<ProductDto>> GetAllProducts();
    }
}
