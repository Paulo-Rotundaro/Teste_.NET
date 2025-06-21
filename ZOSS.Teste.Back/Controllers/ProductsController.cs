using Microsoft.AspNetCore.Mvc;
using ZOSS.Teste.Application.Interfaces;
using ZOSS.Teste.Back.Models;

namespace ZOSS.Teste.Back.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] ProductRequestDTO productDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdProduct = await _productService.CreateAsync(productDto);

            if (createdProduct == null)
                return BadRequest("Categoria não encontrada.");

            return CreatedAtAction(nameof(GetProducts), new { id = createdProduct.Id }, createdProduct);
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _productService.GetAllAsync();
            return Ok(products);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] ProductRequestDTO productDto)
        {
            if (id != productDto.Id)
                return BadRequest("ID da URL e do corpo não conferem.");

            var updatedProduct = await _productService.UpdateAsync(id, productDto);

            if (updatedProduct == null)
                return NotFound("Produto ou categoria não encontrada.");

            return Ok(updatedProduct);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var deleted = await _productService.DeleteAsync(id);

            if (!deleted)
                return NotFound("Produto não encontrado.");

            return NoContent();
        }
    }
}
