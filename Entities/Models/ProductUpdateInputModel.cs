using Entities.Attributes;
using System;

namespace Entities.Models
{
    public class ProductUpdateInputModel : ProductInputModel
    {
        [NonDefault(ErrorMessage = "Id is required.")]
        public Guid Id { get; set; }
    }
}
