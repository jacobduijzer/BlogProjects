using System;
using AutoMapper;
using Products.Domain;

namespace Products.DTO
{
    [AutoMap(typeof(Product))]
    public class ProductDTO
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}
