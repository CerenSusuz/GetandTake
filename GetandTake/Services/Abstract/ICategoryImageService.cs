using GetandTake.Models;

namespace GetandTake.Services.Abstract;

public interface ICategoryImageService
{
    Task Add(IFormFile file, int id);

    void Delete(CategoryImage categoryImage);
}
