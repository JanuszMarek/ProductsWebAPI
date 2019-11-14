using Entities;
using Entities.Models;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository
{
    public class ProductRepository : IProductRepository
    {
        private ApplicationDbContext _dbContext;

        public ProductRepository(ApplicationDbContext context)
        {
            _dbContext = context;
        }

        public Product GetProduct(Guid productId)
        {
            Product product = _dbContext.Products.FirstOrDefault(p => p.Id == productId);
            return product;
        }

        public IEnumerable<Product> GetProducts()
        {
            IEnumerable<Product> products = _dbContext.Products.OrderBy(p => p.Name);
            return products;
        }

        public void CreateProduct(Product product)
        {
            product.Id = new Guid();
            _dbContext.Products.Add(product);
        }

        public void UpdateProduct(Product product)
        {
            // no code in this implementation
        }

        public void DeleteProduct(Product product)
        {
            _dbContext.Products.Remove(product);
        }

        public bool Save()
        {
            return (_dbContext.SaveChanges() >= 0);
        }
    }
}
