using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Models
{
    public abstract class ProductInputModel
    {
        [Required(ErrorMessage = "Product name is missing.")]
        [MaxLength(100, ErrorMessage = "Product name can not be longer than 100 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Price of product is missing.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0.")]
        public decimal Price { get; set; }
    }
}
