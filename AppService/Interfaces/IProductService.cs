using Entities.Models;
using System;

namespace Services.Interfaces
{
    public interface IProductService : IService<ProductDto>
    {
        Guid Create(ProductCreateInputModel productCreate);

        void Update(Guid id, ProductUpdateInputModel productUpdateInputModel);
    }
}
