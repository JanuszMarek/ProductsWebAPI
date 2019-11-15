using Entities.Models.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class Product : IEntity
    {
        public Guid Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }
    }
}
