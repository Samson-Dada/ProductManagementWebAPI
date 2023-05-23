using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductManagementPlaftormAPI.DataLayer;
using ProductManagementPlaftormAPI.Domain.Models;
using ProductManagementPlaftormAPI.Services;

namespace ProductManagementPlaftormAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetAll() 
        {
            var products = await _productService.GetAllProductAsync();
            return Ok(products);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var product =  await  _productService.GetProductByIdAsync(id);
            if(product is null)
            {
                return NotFound($"Product with {id} not found!");
            }
            return Ok(product);
        }

        [HttpPut]

        public async Task<IActionResult> Update(string id, [FromBody] Product product)
        {
            Product productUpdate = await _productService.GetProductByIdAsync(id);
            if (productUpdate is null)
            {
                return NotFound($"Cannot found {productUpdate}");
            }
            await _productService.UpdateProductAsync(product);
            return Ok(product);
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Product product)
        {
            await _productService.CreateProductAsync(product);
            return CreatedAtAction(nameof(GetById), new {product.Id }, product);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if(product is null)
            {
                return NotFound($"Product with {id} not found!");
            }
            await _productService.DeleteProductAsync(id);
            return Ok($"{id} was Deleted Successfully");
        }
    }
}
