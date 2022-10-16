using AutoMapper;
using GetandTake.DataAccess.Repositories;
using GetandTake.Models;
using GetandTake.Services.Abstracts;

namespace GetandTake.Services.Concretes;

public class CategoryManager : ICategoryService
{

    private readonly IBaseRepository<Category> _repository;

    private readonly IMapper _mapper;

    public CategoryManager(IBaseRepository<Category> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task DeleteAsync(int categoryId)
    {
        var category = await _repository.GetAsync(entity => entity.CategoryID == categoryId);
        await _repository.DeleteAsync(category);
    }

    public async Task<IEnumerable<Category>> GetAllAsync()
    {
        var categories = await _repository.GetAllAsync();

        return _mapper.Map<List<Category>>(categories);
    }

    public Task<Category> GetAsync(int categoryId)
    {
        var findCategory = _repository.GetAsync(category => category.CategoryID == categoryId);

        return findCategory;
    }

    public async Task InsertAsync(Category category)
    {
        await _repository.InsertAsync(category);
    }

    public async Task UpdateAsync(int categoryId, Category category)
    {
        var findCategory = await _repository.GetAsync(category => category.CategoryID == categoryId);
        if (findCategory != null)
        {
            category.CategoryID = categoryId;
            await _repository.UpdateAsync(category);
        }
    }
}
