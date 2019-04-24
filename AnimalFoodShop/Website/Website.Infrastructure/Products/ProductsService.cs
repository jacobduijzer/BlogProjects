using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Website.Application.Products;
using Website.Domain.Products;

namespace Website.Infrastructure.Products
{
    public class ProductsService : IProductsService
    {
        private readonly IProductsApi _productsApi;
        private readonly ILogger<ProductsService> _logger;

        public ProductsService(IProductsApi productsApi, ILogger<ProductsService> logger)
        {
            _productsApi = productsApi;
            _logger = logger;
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            var products = await _productsApi.GetAllProducts().ConfigureAwait(false);

            return products.Select(product => new Product(product.Id, product.Name));
        }
            
    }
}
