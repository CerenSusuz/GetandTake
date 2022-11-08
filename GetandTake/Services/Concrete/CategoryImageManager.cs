using GetandTake.Core.Helper;
using GetandTake.DataAccess.Repositories.Abstract;
using GetandTake.Models;
using GetandTake.Services.Abstract;

namespace GetandTake.Services.Concrete;

public class CategoryImageManager : ICategoryImageService
{
    private readonly ICategoryImageRepository _categoryImageRepository;

    public CategoryImageManager(ICategoryImageRepository categoryImageRepository)
    {
        _categoryImageRepository = categoryImageRepository;
    }

    public async Task Add(IFormFile file,int id)
    {
        CategoryImage image = new()
        {
            CategoryId = id,
            ImagePath = FileHelper.Add(file)
        };
        await _categoryImageRepository.CreateAsync(image);
    }

    public void Delete(CategoryImage categoryImage)
    {
        FileHelper.Delete(categoryImage.ImagePath);
        _categoryImageRepository.Delete(entity => entity.Id == categoryImage.Id);

    }
}
