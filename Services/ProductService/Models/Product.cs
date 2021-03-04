using System;

namespace ProductService.Models
{
    public class Product : IEntity
    {
        public decimal Price { get; set; }
        public string Name { get; set; }
        public string ExternalId { get; set; }
        public Guid SystemId { get; set; }
    }
}
