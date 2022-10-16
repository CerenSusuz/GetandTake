using GetandTake.Models.Base;
using GetandTake.Models.DTOs.BaseDTO;
using GetandTake.Models.DTOs.ListDTO;

namespace GetandTake.Services.Abstracts;

public interface IProductService
{

    Task<IEnumerable<ProductsDTO>> GetAllAsync();

    Task<IEnumerable<ProductsDTO>> GetAllByCategoryIdAsync(int categoryId);

    Task<IEnumerable<ProductsDTO>> GetAllBySupplierIdAsync(int supplierId);

    Task<ProductsDTO> GetByIdAsync(int productId);

    Task UpdateAsync(int productId, ProductDTO productDto);

    Task InsertAsync(ProductDTO productDto);

    Task DeleteAsync(int productId);
}
