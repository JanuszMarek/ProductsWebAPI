using AutoMapper;
using Entities.Models;
using Microsoft.Extensions.Logging;
using Repository.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public class ProductService : IProductService
    {
        private IProductRepository _repository;
        private IMapper _mapper;
        private readonly ILogger<ProductService> _logger;

        public ProductService(IProductRepository productRepository, IMapper mapper, ILogger<ProductService> logger)
        {
            _repository = productRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public IEnumerable<ProductDto> GetEntites()
        {
            _logger.LogInformation($"Get {nameof(Product)}s: start");
            IEnumerable<Product> products = _repository.GetAll().OrderBy(p => p.Name);
            IEnumerable<ProductDto> productsDto = _mapper.Map<IEnumerable<ProductDto>>(products);
            _logger.LogInformation($"Get {nameof(Product)}s: success");

            return productsDto;
        }

        public ProductDto GetById(Guid id)
        {
            _logger.LogInformation($"Get {nameof(Product)} with id {id}: start");
            Product product = _repository.GetById(id);
            ProductDto productDto = _mapper.Map<ProductDto>(product);
            _logger.LogInformation($"Get {nameof(Product)} with id {id}: success");

            return productDto;
        }

        public Guid Create(ProductCreateInputModel productCreate)
        {
            _logger.LogInformation($"Create new {nameof(Product)}: start");
            Product product = _mapper.Map<Product>(productCreate);
            product.Id = new Guid();
            _repository.Create(product);

            if (!_repository.Save())
            {
                throw new Exception($"Creating {nameof(Product)} {productCreate.Name} failed on server");
            }
            _logger.LogInformation($"Create new {nameof(Product)}: sucess, created Id: {product.Id}");

            return product.Id;
        }

        public void Update(Guid id, ProductUpdateInputModel productUpdateInputModel)
        {
            _logger.LogInformation($"Update {nameof(Product)} entity with {id}: start");
            Product product = _repository.GetById(id);

            //overwrite id - id from path more important than passed in model
            productUpdateInputModel.Id = id;

            _mapper.Map(productUpdateInputModel, product);
            _repository.Update(product);

            if (!_repository.Save())
            {
                throw new Exception($"Updating {nameof(Product)} {productUpdateInputModel.Name} failed on server");
            }
            _logger.LogInformation($"Update {nameof(Product)} entity with {id}: sucess");
        }

        public void Delete(Guid id)
        {
            _logger.LogInformation($"Delete {nameof(Product)} entity with {id}: start");
            Product product = _repository.GetById(id);
            _repository.Delete(product);

            if (!_repository.Save())
            {
                throw new Exception($"Deleting {nameof(Product)} {product.Name} failed on server");
            }
            _logger.LogInformation($"Delete {nameof(Product)} entity with {id}: sucess");
        }

        public bool Exists(Guid id)
        {
            return _repository.Exists(id);
        }
    }
}
