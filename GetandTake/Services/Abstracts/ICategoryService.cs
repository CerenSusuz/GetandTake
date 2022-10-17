using GetandTake.Models;

namespace GetandTake.Services.Abstracts;

public interface ICategoryService
{

    IEnumerable<Category> GetAll();

    Category GetById(int categoryId);

    Task UpdateAsync(int categoryId, Category category);

    Task CreateAsync(Category category);

    void Delete(int categoryId);
}
