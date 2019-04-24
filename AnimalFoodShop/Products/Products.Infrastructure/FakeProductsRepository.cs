using System;
using System.Collections.Generic;
using Products.Domain;
using Products.FakeData;
using SharedKernel.Repository;

namespace Products.Infrastructure
{
    public class FakeProductsRepository : IRepository<Product>
    {
        public Product Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetAll() =>
            FakeDataHelper.GetFakeProducts(100);
    }
}
