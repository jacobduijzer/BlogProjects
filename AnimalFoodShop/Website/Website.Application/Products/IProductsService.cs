using System.Collections.Generic;
using System.Threading.Tasks;
using Website.Domain.Products;

namespace Website.Application.Products
{
    public interface IProductsService
    {
        Task<IEnumerable<Product>> GetAllProducts();
    }
}
