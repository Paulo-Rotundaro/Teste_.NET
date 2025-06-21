using ZOSS.Teste.Application.Interfaces;
using ZOSS.Teste.Back.DTOs;
using ZOSS.Teste.Back.Models;
using ZOSS.Teste.Domain.Interfaces;

namespace ZOSS.Teste.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public ProductService(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<IEnumerable<ProductResponseDTO?>> GetAllAsync()
        {
            var products = await _productRepository.GetAllAsync();
            return products.Select(p => new ProductResponseDTO
            {
                Id = p!.Id,
                Name = p.Name,
                Description = p.Description,
                Value = p.Value,
                CategoryId = p.CategoryId,
                CategoryName = p.Category?.Name ?? string.Empty
            });
        }

        public async Task<ProductResponseDTO?> GetByIdAsync(int id)
        {
            var p = await _productRepository.GetByIdAsync(id);
            if (p == null) return null;

            return new ProductResponseDTO
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Value = p.Value,
                CategoryId = p.CategoryId,
                CategoryName = p.Category?.Name ?? string.Empty
            };
        }

        public async Task<ProductResponseDTO?> CreateAsync(ProductRequestDTO dto)
        {
            var category = await _categoryRepository.GetByIdAsync(dto.CategoryId);
            if (category == null)
                return null;

            var product = new Product
            {
                Name = dto.Name,
                Description = dto.Description,
                Value = dto.Value,
                CategoryId = dto.CategoryId
            };

            await _productRepository.AddAsync(product);

            return new ProductResponseDTO
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Value = product.Value,
                CategoryId = product.CategoryId,
                CategoryName = category.Name 
            };
        }

        public async Task<ProductResponseDTO?> UpdateAsync(int id, ProductRequestDTO dto)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null) return null;

            product.Name = dto.Name;
            product.Description = dto.Description;
            product.Value = dto.Value;
            product.CategoryId = dto.CategoryId;

            await _productRepository.UpdateAsync(product);

            return new ProductResponseDTO
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Value = product.Value,
                CategoryId = product.CategoryId,
                CategoryName = product.Category?.Name ?? string.Empty
            };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null) return false;

            await _productRepository.DeleteAsync(product);
            return true;
        }
    }
}
