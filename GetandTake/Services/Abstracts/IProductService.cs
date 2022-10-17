using GetandTake.Models.DTOs.BaseDTO;
using GetandTake.Models.DTOs.ListDTO;

namespace GetandTake.Services.Abstracts;

public interface IProductService
{

    IEnumerable<ProductsDTO> GetAll();

    IEnumerable<ProductsDTO> GetAllByCategoryId(int categoryId);

    IEnumerable<ProductsDTO> GetAllBySupplierId(int supplierId);

    ProductsDTO GetById(int productId);

    Task UpdateAsync(int productId, ProductDTO productDto);

    Task CreateAsync(ProductDTO productDto);

    void Delete(int productId);
}
