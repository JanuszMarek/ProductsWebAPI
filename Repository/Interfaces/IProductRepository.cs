using Entities.Models;
using System;
using System.Collections.Generic;

namespace Repository.Interfaces
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
