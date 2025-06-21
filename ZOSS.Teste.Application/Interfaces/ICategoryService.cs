using ZOSS.Teste.Back.DTOs;

namespace ZOSS.Teste.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDTO?>> GetAllAsync();
        Task<CategoryDTO?> GetByIdAsync(int id);
        Task<CategoryDTO?> CreateAsync(CategoryDTO categoryDto);
    }
}