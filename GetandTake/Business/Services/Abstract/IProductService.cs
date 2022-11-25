using GetandTake.Models.DTOs.DetailDTO;
using GetandTake.Models.DTOs.ResponseDTO;

namespace GetandTake.Business.Services.Abstract;

public interface IProductService
{
    Task<List<ProductResponse>> GetAllAsync();

    Task<List<ProductResponse>> GetAllByCategoryIdAsync(int categoryId);

    Task<List<ProductResponse>> GetAllBySupplierIdAsync(int supplierId);

    Task<List<ProductResponse>> GetByMaxAmountOfAsync(int maximumAmount);

    Task<ProductResponse> GetByIdAsync(int productId);

    Task UpdateAsync(int productId, ProductDetail productDto);

    Task CreateAsync(ProductDetail productDto);

    void Delete(int productId);
}
