using GetandTake.Models.DTOs.BaseDTO;
using GetandTake.Models.DTOs.ListDTO;

namespace GetandTake.Services.Abstract;

public interface IProductService
{

    IEnumerable<ProductsDTO> GetAll();

    IEnumerable<ProductsDTO> GetAllByCategoryId(int categoryId);

    IEnumerable<ProductsDTO> GetAllBySupplierId(int supplierId);
    
    IEnumerable<ProductsDTO> GetByMaximumAmount(int maximumAmount);

    ProductsDTO GetById(int productId);

    Task UpdateAsync(int productId, ProductDTO productDto);

    Task CreateAsync(ProductDTO productDto);

    void Delete(int productId);
}
