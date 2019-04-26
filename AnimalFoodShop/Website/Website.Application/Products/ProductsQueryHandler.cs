using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using Website.Domain.Products;

namespace Website.Application.Products
{
    public class ProductsQueryHandler : IRequestHandler<ProductsQuery, IEnumerable<Product>>
    {
        private readonly ICachedProductsDecorator _cachedProductsService;
        private readonly ILogger<ProductsQueryHandler> _logger;

        public ProductsQueryHandler(ICachedProductsDecorator cachedProductsService, ILogger<ProductsQueryHandler> logger)
        {
            _cachedProductsService = cachedProductsService;
            _logger = logger;
        }

        public async Task<IEnumerable<Product>> Handle(ProductsQuery request, CancellationToken cancellationToken)
        {
            _logger.LogDebug($"{nameof(ProductsQueryHandler)}-Handle");
            return await _cachedProductsService.GetAllProducts().ConfigureAwait(false);
        }    
    }
}
