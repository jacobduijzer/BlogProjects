using System;

namespace Website.Domain.Products
{
    public class Product
    {
        public readonly Guid Id;

        public readonly string Name;

        public Product(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
