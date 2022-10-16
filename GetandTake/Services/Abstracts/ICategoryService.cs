using GetandTake.Models;

namespace GetandTake.Services.Abstracts;

public interface ICategoryService
{

    Task<IEnumerable<Category>> GetAllAsync();

    Task<Category> GetAsync(int categoryId);

    Task UpdateAsync(int categoryId, Category category);

    Task InsertAsync(Category category);

    Task DeleteAsync(int categoryId);
}
