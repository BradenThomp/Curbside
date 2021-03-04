using System;

namespace ProductService.Models
{
    public interface IEntity
    {
        public Guid SystemId { get; set; }
    }
}
