using ZOSS.Teste.Back.DTOs;

namespace ZOSS.Teste.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryResponseDTO?>> GetAllAsync();
        Task<CategoryResponseDTO?> GetByIdAsync(int id);
        Task<CategoryResponseDTO?> CreateAsync(CategoryRequestDTO categoryDto);
    }
}