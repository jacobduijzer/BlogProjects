using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Website.Application.Products;
using Website.Domain.Products;

namespace Website.Infrastructure.Products
{
    public class CachedProductsService : ICachedProductsDecorator
    {
        private readonly IMemoryCache _memoryCache;
        private readonly IProductsService _productsService;
        private readonly ILogger<CachedProductsService> _logger;

        public CachedProductsService(IMemoryCache memoryCache, IProductsService productsService, ILogger<CachedProductsService> logger)
        {
            _memoryCache = memoryCache;
            _productsService = productsService;
            _logger = logger;
        }

        public async Task<IEnumerable<Product>> GetAllProducts() =>
            await _memoryCache.GetOrCreateAsync<IEnumerable<Product>>("all-products", async (entry) =>
            {
                _logger.LogDebug("CachedProductsService: GETTING ALL PRODUCTS FROM SERVICE");
                await Task.Delay(3000);
                entry.AbsoluteExpiration = DateTimeOffset.Now.AddSeconds(30);
                return await _productsService.GetAllProducts().ConfigureAwait(false);
            }).ConfigureAwait(false);
    }
}
