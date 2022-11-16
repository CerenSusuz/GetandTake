using GetandTake.Core.Aspects.Caching;
using GetandTake.Core.Utilities.Helper;
using GetandTake.DataAccess.Repositories.Abstract;
using GetandTake.Models;
using GetandTake.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace GetandTake.Services.Concrete;

public class CategoryManager : ICategoryService
{
    private readonly ICategoryRepository _repository;

    public CategoryManager(ICategoryRepository repository) =>
        _repository = repository;

    [CacheRemoveAspect("ICategoryService.Get")]
    public void Delete(int categoryId) =>
        _repository.Delete(entity => entity.CategoryID == categoryId);

    [CacheRemoveAspect("ICategoryService.Get")]
    public async Task CreateAsync(Category category) =>
        await _repository.CreateAsync(category);

    [CacheRemoveAspect("ICategoryService.Get")]
    public async Task UpdateAsync(int categoryId, Category category)
    {
        var findCategory = await _repository.GetAsync(category => category.CategoryID == categoryId);
        if (findCategory != null)
        {
            category.CategoryID = categoryId;
            _repository.Update(category);
        }
    }

    [CacheAspect]
    public async Task<List<Category>> GetAllAsync() =>
        await _repository.GetItemsAsync();

    [CacheAspect]
    public async Task<Category> GetByIdAsync(int categoryId) =>
        await _repository.GetAsync(category => category.CategoryID == categoryId);

    [ResponseCache(NoStore = false, Duration = 10, Location = ResponseCacheLocation.Any)]
    public async Task UploadImage(IFormFile file, int id)
    {
        var category = await GetByIdAsync(id);
        category.ImagePath = FileHelper.Upload(file);
        _repository.Update(category);
    }
}