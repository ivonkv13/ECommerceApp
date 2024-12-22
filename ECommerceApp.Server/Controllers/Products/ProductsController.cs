using ECommerceApp.Server.Controllers.Products.Dtos;
using ECommerceApp.Server.Services;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApp.Server.Controllers.Products
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductsController(IProductService service)
        {
            _service = service;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _service.GetAllProductsAsync();

            return Ok(products);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await _service.GetProductByIdAsync(id);

            if (product == null) return NotFound();

            return Ok(product);
        }

        [HttpPost("CreateProduct")]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _service.AddProductAsync(dto);

            return Ok(dto);
        }

        [HttpPut("UpdateProduct")]
        public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductDto dto)
        {
            if (!await _service.DoesProductExistAsync(dto.Id)) return NotFound();

            if (!ModelState.IsValid) return BadRequest(ModelState);

            await _service.UpdateProductAsync(dto);

            return Ok(dto);
        }

        [HttpDelete("DeleteProduct")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            if (!await _service.DoesProductExistAsync(id)) return NotFound();

            await _service.DeleteProductAsync(id);

            return Ok(id);
        }
    }
}
