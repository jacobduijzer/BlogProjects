using System.Collections.Generic;
using MediatR;
using Microsoft.Extensions.Logging;
using Products.Domain;
using SharedKernel.Repository;

namespace Products.Application
{
    public class ProductsQueryHandler : RequestHandler<ProductsQuery, IEnumerable<Product>>
    {
        private readonly IRepository<Product> _productsRepository;
        private readonly ILogger<ProductsQueryHandler> _logger;

        public ProductsQueryHandler(IRepository<Product> productsRepository, ILogger<ProductsQueryHandler> logger)
        {
            _productsRepository = productsRepository;
            _logger = logger;
        }

        protected override IEnumerable<Product> Handle(ProductsQuery request) =>
            _productsRepository.GetAll();
    }
}
