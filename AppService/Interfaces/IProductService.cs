using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IProductService
    {
        IEnumerable<ProductDto> GetProducts();

        ProductDto GetProduct(Guid id);

        Guid CreateProduct(ProductCreateInputModel productCreate);

        void UpdateProduct(Guid id, ProductUpdateInputModel productUpdateInputModel);

        void DeleteProduct(Guid id);

        bool ProductExists(Guid id);
    }
}
