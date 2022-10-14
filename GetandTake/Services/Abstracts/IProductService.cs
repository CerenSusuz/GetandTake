using GetandTake.Models.Base;
using GetandTake.Models.DTOs.BaseDTO;
using GetandTake.Models.DTOs.ListDTO;

namespace GetandTake.Services.Abstracts
{
    public interface IProductService
    {
        Task<List<ProductsDTO>> GetAllAsync();
        Task<List<ProductsDTO>> GetAllByCategoryAsync(int categoryId);
        Task<List<ProductsDTO>> GetAllBySupplierAsync(int supplierId);
        Task<ProductsDTO> GetAsync(int id);
        Task UpdateAsync(int id, ProductDTO dto);
        Task InsertAsync(ProductDTO dto);
        Task DeleteAsync(int id);
    }
}
