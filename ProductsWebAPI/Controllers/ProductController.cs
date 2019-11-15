using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using ProductsWebAPI.ActionFilters;
using Services.Interfaces;

namespace ProductsWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        // GET api/product
        [HttpGet]
        public IActionResult GetProducts()
        {
            IEnumerable<ProductDto> products = _productService.GetEntites();

            return new JsonResult(products);
        }

        // GET api/product/5
        [HttpGet("{id}")]
        [ServiceFilter(typeof(ExistValidationFilterAttribute<ProductDto, IProductService>))]
        public IActionResult GetProduct(Guid id)
        {
            ProductDto product = _productService.GetById(id);

            if(product == null)
            {
                return NotFound();
            }

            return new JsonResult(product);
        }

        // POST api/product
        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public IActionResult CreateProduct([FromBody] ProductCreateInputModel productCreate)
        {
            Guid createdId = _productService.Create(productCreate);

            return new JsonResult(createdId);
        }

        // PUT api/product/5
        [HttpPut("{id}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [ServiceFilter(typeof(ExistValidationFilterAttribute<ProductDto, IProductService>))]
        public IActionResult UpdateProduct(Guid id, [FromBody] ProductUpdateInputModel productUpdate)
        {
            _productService.Update(id, productUpdate);

            return NoContent();
        }

        // DELETE api/product/5
        [HttpDelete("{id}")]
        [ServiceFilter(typeof(ExistValidationFilterAttribute<ProductDto, IProductService>))]
        public IActionResult DeleteProduct(Guid id)
        {
            _productService.Delete(id);

            return NoContent();
        }
    }
}
