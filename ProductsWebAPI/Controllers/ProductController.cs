using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
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
            IEnumerable<ProductDto> products = _productService.GetProducts();

            return new JsonResult(products);
        }

        // GET api/product/5
        [HttpGet("{id}")]
        public IActionResult GetProduct(Guid id)
        {
            ProductDto product = _productService.GetProduct(id);

            if(product == null)
            {
                return NotFound();
            }

            return new JsonResult(product);
        }

        // POST api/product
        [HttpPost]
        public IActionResult CreateProduct([FromBody] ProductCreateInputModel productCreate)
        {
            if (productCreate == null)
            {
                return BadRequest();
            }

            Guid createdId = _productService.CreateProduct(productCreate);

            return new JsonResult(createdId);
        }

        // PUT api/product/5
        [HttpPut("{id}")]
        public IActionResult UpdateProduct(Guid id, [FromBody] ProductUpdateInputModel productUpdate)
        {
            if (productUpdate == null)
            {
                return BadRequest();
            }

            if(!_productService.ProductExists(id))
            {
                return NotFound();
            }

            _productService.UpdateProduct(id, productUpdate);

            return NoContent();
        }

        // DELETE api/product/5
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(Guid id)
        {
            if (!_productService.ProductExists(id))
            {
                return NotFound();
            }

            _productService.DeleteProduct(id);

            return NoContent();
        }
    }
}
