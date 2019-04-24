using System;
using System.Collections.Generic;
using Bogus;
using Products.Domain;

namespace Products.FakeData
{
    public static class FakeDataHelper
    {
        public static IEnumerable<Product> GetFakeProducts(int amount)
        {
            Randomizer.Seed = new Random(8675309);

            return new Faker<Product>()
                .CustomInstantiator(faker => new Product(Guid.NewGuid(), faker.Commerce.Product()))
                .Generate(amount);
        }
    }
}
