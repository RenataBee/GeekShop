using GeekShop.ProductApi.DTOs;
using GeekShop.ProductApi.IServices;
using Microsoft.AspNetCore.Mvc;

namespace GeekShop.ProductApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService ?? throw new ArgumentNullException(nameof(productService));
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var productsDtos = await _productService.GetProducts();
            return Ok(productsDtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var productDto = await _productService.GetProductById(id);
            
            if (productDto.Id <= 0) return NotFound();
            return Ok(productDto);
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] ProductDto input)
        {
            var productDto = await _productService.AddProduct(input);
            return Ok(productDto);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct([FromBody] ProductDto input)
        {
            var productDto = await _productService.UpdateProduct(input);
            return Ok(productDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var status = await _productService.DeleteProduct(id);

            if (!status) return BadRequest();
            return Ok(status);
        }
    }
}
