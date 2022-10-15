using GetandTake.Models.Base;
using GetandTake.Models.DTOs.BaseDTO;
using GetandTake.Models.DTOs.ListDTO;

namespace GetandTake.Services.Abstracts
{
    public interface IProductService
    {
        Task<IEnumerable<ProductsDTO>> GetAllAsync();
        Task<IEnumerable<ProductsDTO>> GetAllByCategoryAsync(int categoryId);
        Task<IEnumerable<ProductsDTO>> GetAllBySupplierAsync(int supplierId);
        Task<ProductsDTO> GetAsync(int id);
        Task UpdateAsync(int id, ProductDTO dto);
        Task InsertAsync(ProductDTO dto);
        Task DeleteAsync(int id);
    }
}
