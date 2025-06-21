using ZOSS.Teste.Back.DTOs;
using ZOSS.Teste.Back.Models;

namespace ZOSS.Teste.Application.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductResponseDTO?>> GetAllAsync();
        Task<ProductResponseDTO?> GetByIdAsync(int id);
        Task<ProductResponseDTO?> CreateAsync(ProductRequestDTO productDto);
        Task<ProductResponseDTO?> UpdateAsync(int id, ProductRequestDTO productDto);
        Task<bool> DeleteAsync(int id);
    }
}
