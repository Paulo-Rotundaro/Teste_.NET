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

        public async Task<IEnumerable<CategoryDTO?>> GetAllAsync()
        {
            var categories = await _categoryRepository.GetAllAsync();
            return categories.Select(c => new CategoryDTO
            {
                Id = c.Id,
                Name = c.Name
            });
        }

        public async Task<CategoryDTO?> GetByIdAsync(int id)
        {
            var c = await _categoryRepository.GetByIdAsync(id);
            if (c == null) return null;

            return new CategoryDTO { Id = c.Id, Name = c.Name };
        }

        public async Task<CategoryDTO?> CreateAsync(CategoryDTO categoryDto)
        {
            var category = new Category { Name = categoryDto.Name };
            await _categoryRepository.AddAsync(category);

            return new CategoryDTO { Id = category.Id, Name = category.Name };
        }
    }
}