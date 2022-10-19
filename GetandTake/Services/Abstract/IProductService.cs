using GetandTake.Models.DTOs.BaseDTO;
using GetandTake.Models.DTOs.ListDTO;

namespace GetandTake.Services.Abstract;

public interface IProductService
{
    Task<List<ProductsDTO>> GetAllAsync();

    Task<List<ProductsDTO>> GetAllByCategoryIdAsync(int categoryId);

    Task<List<ProductsDTO>> GetAllBySupplierIdAsync(int supplierId);

    Task<List<ProductsDTO>> GetByMaximumAmountAsync(int maximumAmount);

    Task<ProductsDTO> GetByIdAsync(int productId);

    Task UpdateAsync(int productId, ProductDTO productDto);

    Task CreateAsync(ProductDTO productDto);

    void Delete(int productId);
}
