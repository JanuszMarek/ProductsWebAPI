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

        public Product GetById(Guid id)
        {
            Product product = _dbContext.Products.FirstOrDefault(p => p.Id == id);
            return product;
        }

        public IEnumerable<Product> GetAll()
        {
            IEnumerable<Product> products = _dbContext.Products.OrderBy(p => p.Name);
            return products;
        }

        public void Create(Product product)
        {
            product.Id = new Guid();
            _dbContext.Products.Add(product);
        }

        public void Update(Product product)
        {
            // no code in this implementation
        }

        public void Delete(Product product)
        {
            _dbContext.Products.Remove(product);
        }

        public bool Save()
        {
            return (_dbContext.SaveChanges() >= 0);
        }
    }
}
