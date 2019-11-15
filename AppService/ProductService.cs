using AutoMapper;
using Entities.Models;
using Repository.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services
{
    public class ProductService : IProductService
    {
        private IProductRepository _repository;
        private IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _repository = productRepository;
            _mapper = mapper;
        }

        public IEnumerable<ProductDto> GetProducts()
        {
            IEnumerable<Product> products = _repository.GetAll().OrderBy(p => p.Name);
            IEnumerable<ProductDto> productsDto = _mapper.Map<IEnumerable<ProductDto>>(products);

            return productsDto;
        }

        public ProductDto GetProduct(Guid id)
        {
            Product product = _repository.GetById(id);
            ProductDto productDto = _mapper.Map<ProductDto>(product);

            return productDto;
        }

        public Guid CreateProduct(ProductCreateInputModel productCreate)
        {
            Product product = _mapper.Map<Product>(productCreate);
            product.Id = new Guid();

            _repository.Create(product);

            if (!_repository.Save())
            {
                throw new Exception($"Creating product {productCreate.Name} failed on server");
            }

            return product.Id;
        }

        public void UpdateProduct(Guid id, ProductUpdateInputModel productUpdateInputModel)
        {
            Product productToUpdate = _repository.GetById(id);

            //overwrite id - id from path more important than passed in model
            productUpdateInputModel.Id = id;

            productToUpdate = _mapper.Map<Product>(productUpdateInputModel);
            _repository.Update(productToUpdate);

            if (!_repository.Save())
            {
                throw new Exception($"Updating product {productUpdateInputModel.Name} failed on server");
            }
        }

        public void DeleteProduct(Guid id)
        {
            Product product = _repository.GetById(id);
            _repository.Delete(product);

            if (!_repository.Save())
            {
                throw new Exception($"Deleting product {product.Name} failed on server");
            }
        }

        public bool ProductExists(Guid id)
        {
            return _repository.Exists(id);
        }
    }
}
