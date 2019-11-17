using Entities.Models.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public abstract class ProductInputModel : IEntityInputModel
    {
        [Required(ErrorMessage = "Product name is missing.")]
        [MaxLength(100, ErrorMessage = "Product name can not be longer than 100 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Price of product is missing.")]
        [Range(0.01, 999999.99, ErrorMessage = "Price must be greater than 0 and lower than 1M.")]
        public decimal Price { get; set; }
    }
}
