using System;
using System.ComponentModel.DataAnnotations;

namespace ProductsWebAPI.Models
{
    public class Product
    {
        public Guid Id { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Please enter a positive price")]
        public decimal Price { get; set; }
    }
}
