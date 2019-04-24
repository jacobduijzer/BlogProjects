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
        private readonly IProductsService _productsService;
        private readonly ILogger<ProductsQueryHandler> _logger;

        public ProductsQueryHandler(IProductsService productsService, ILogger<ProductsQueryHandler> logger)
        {
            _productsService = productsService;
            _logger = logger;
        }

        public async Task<IEnumerable<Product>> Handle(ProductsQuery request, CancellationToken cancellationToken)
        {
            _logger.LogDebug($"{nameof(ProductsQueryHandler)}-Handle");
            return await _productsService.GetAllProducts().ConfigureAwait(false);
        }    
    }
}
