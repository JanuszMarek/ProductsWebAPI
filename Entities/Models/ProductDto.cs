using Entities.Models.Interfaces;
using System;

namespace Entities.Models
{
    public class ProductDto : IEntityDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }
    }
}
