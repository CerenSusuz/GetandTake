using GetandTake.Models;

namespace GetandTake.Services.Abstract;

public interface ICategoryService
{
    Task<List<Category>> GetAllAsync();

    Task<Category> GetByIdAsync(int categoryId);

    Task UpdateAsync(int categoryId, Category category);

    Task CreateAsync(Category category);

    void Delete(int categoryId);

    Task UploadImage(IFormFile file, int id);

    Task EditImage(IFormFile file, int id);
}
