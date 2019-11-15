using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IProductService : IService<ProductDto>
    {
        Guid Create(ProductCreateInputModel productCreate);

        void Update(Guid id, ProductUpdateInputModel productUpdateInputModel);
    }
}
