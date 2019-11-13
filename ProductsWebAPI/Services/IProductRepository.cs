using ProductsWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsWebAPI.Services
{
    public interface IProductRepository
    {
        Product GetProduct(Guid productId);

        IEnumerable<Product> GetProducts();

        void CreateProduct(Product product);

        void UpdateProduct(Product product);

        void DeleteProduct(Product product);

        bool Save();
    }
}
