using IGSMarketPlace.API.Model;
using IGSMarketPlace.API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IGSMarketPlace.API.Controllers
{
    [ApiController]
    [Route("v1")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IProductRepository _productRepository;

        public ProductController(ILogger<ProductController> logger, IProductRepository productRepository)
        {
            _logger = logger;
            _productRepository = productRepository;
        }

        [HttpGet("product/{id}")]
        public IActionResult GetProduct(int id)
        {
            ProductDTO productDTO = _productRepository.GetProduct(id);
            if(productDTO == null)
            {
                return NotFound();
            }
            return Ok(productDTO);
        }

        [HttpGet("products")]
        public IActionResult GetProducts()
        {
            return Ok(_productRepository.GetProducts());
        }

        [HttpPost("product")]
        public IActionResult AddProduct([FromForm]ProductInput productInput)
        {
            if(string.IsNullOrWhiteSpace(productInput.Name) || string.IsNullOrWhiteSpace(productInput.Price) )
            {
                return BadRequest();
            }
            _productRepository.AddProduct(productInput.Name, productInput.Price);
            return Ok();
        }

        [HttpPut("product/{id}")]
        public IActionResult UpdateProduct(int id, [FromForm] ProductInput productInput)
        {
            ProductDTO productDTO = _productRepository.GetProduct(id);
            if( productDTO == null )
            {
                return NotFound();
            }
            if( string.IsNullOrWhiteSpace(productInput.Name))
            {
                if(string.IsNullOrWhiteSpace(productInput.Price))
                {
                    return BadRequest();
                }
                else
                {
                    productDTO.Price = productInput.Price;
                }
            }
            else
            {
                productDTO.Name = productInput.Name;
                if( !string.IsNullOrWhiteSpace(productInput.Price) )
                {
                    productDTO.Price = productInput.Price;
                }
            }

            _productRepository.UpdateProduct(productDTO);
            return Ok();
        }

        [HttpDelete("product/{id}")]
        public IActionResult DeleteProduct(int id)
        {
            if(!_productRepository.ProductExists(id))
            {
                return NotFound();
            }
            _productRepository.DeleteProduct(id);
            return Ok();
        }

    }
}
