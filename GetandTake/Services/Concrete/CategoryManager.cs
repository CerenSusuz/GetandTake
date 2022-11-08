using GetandTake.Core.Helper;
using GetandTake.DataAccess.Repositories.Abstract;
using GetandTake.Models;
using GetandTake.Services.Abstract;

namespace GetandTake.Services.Concrete;

public class CategoryManager : ICategoryService
{
    private readonly ICategoryRepository _repository;

    public CategoryManager(ICategoryRepository repository) =>
        _repository = repository;

    public void Delete(int categoryId) =>
        _repository.Delete(entity => entity.CategoryID == categoryId);

    public async Task CreateAsync(Category category) =>
        await _repository.CreateAsync(category);

    public async Task UpdateAsync(int categoryId, Category category)
    {
        var findCategory = await _repository.GetAsync(category => category.CategoryID == categoryId);
        if (findCategory != null)
        {
            category.CategoryID = categoryId;
            _repository.Update(category);
        }
    }

    public async Task<List<Category>> GetAllAsync() =>
        await _repository.GetItemsAsync();

    public async Task<Category> GetByIdAsync(int categoryId) =>
        await _repository.GetAsync(category => category.CategoryID == categoryId);

    public async Task UploadImage(IFormFile file, int id)
    {
        var category = await GetByIdAsync(id);
        if (category.ImagePath == null)
        {
            category.ImagePath = FileHelper.Add(file);
            _repository.Update(category);
        }
    }

    public async Task EditImage(IFormFile file, int id)
    {
        var category = await GetByIdAsync(id);
        if (category.ImagePath != null)
        {
            category.CategoryID = id;
            category.ImagePath = FileHelper.Add(file);
            _repository.Update(category);
        }
    }
}