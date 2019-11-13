using System;
using System.ComponentModel.DataAnnotations;

namespace ProductsWebAPI.Models
{
    public class Product
    {
        public Guid Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }
    }
}
