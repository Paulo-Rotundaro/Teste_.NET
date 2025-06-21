using ZOSS.Teste.Application.Interfaces;
using ZOSS.Teste.Back.DTOs;
using ZOSS.Teste.Back.Models;
using ZOSS.Teste.Domain.Interfaces;

namespace ZOSS.Teste.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<IEnumerable<CategoryResponseDTO?>> GetAllAsync()
        {
            var categories = await _categoryRepository.GetAllAsync();
            return categories.Select(c => new CategoryResponseDTO
            {
                Id = c.Id,
                Name = c.Name
            });
        }

        public async Task<CategoryResponseDTO?> GetByIdAsync(int id)
        {
            var c = await _categoryRepository.GetByIdAsync(id);
            if (c == null) return null;

            return new CategoryResponseDTO { Id = c.Id, Name = c.Name };
        }

        public async Task<CategoryResponseDTO?> CreateAsync(CategoryRequestDTO categoryDto)
        {
            var category = new Category { Name = categoryDto.Name };
            await _categoryRepository.AddAsync(category);
            return new CategoryResponseDTO { Id = category.Id, Name = category.Name };
        }

        Task<IEnumerable<CategoryResponseDTO?>> ICategoryService.GetAllAsync()
        {
            throw new NotImplementedException();
        }

        Task<CategoryResponseDTO?> ICategoryService.GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}