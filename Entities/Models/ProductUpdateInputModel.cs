using Entities.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Models
{
    public class ProductUpdateInputModel : ProductInputModel
    {
        [NonDefault(ErrorMessage = "Id is required.")]
        public Guid Id { get; set; }
    }
}
