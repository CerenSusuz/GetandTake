using GetandTake.Models;
using GetandTake.Models.DTOs.DetailDTO;
using GetandTake.Models.DTOs.ResponseDTO;

namespace GetandTake.Business.Services.Abstract;

public interface ICategoryService
{
    Task<List<CategoryResponse>> GetAllAsync();

    Task<CategoryResponse> GetByIdAsync(int categoryId);

    Task<string> GetImageByCategoryIdAsync(int categoryId);

    Task UpdateAsync(int categoryId, CategoryDetail categoryDetail);

    Task CreateAsync(CategoryDetail categoryDetail);

    void Delete(int categoryId);

    Task UploadImageAsync(IFormFile file, int id);
}
