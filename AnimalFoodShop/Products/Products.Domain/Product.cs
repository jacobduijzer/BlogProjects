using System;

namespace Products.Domain
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
