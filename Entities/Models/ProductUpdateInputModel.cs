using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Models
{
    public class ProductUpdateInputModel : ProductInputModel
    {
        [Required(ErrorMessage = "Id of product is missing.")]
        public Guid Id { get; set; }
    }
}
