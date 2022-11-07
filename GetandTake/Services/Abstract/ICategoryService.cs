using GetandTake.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace GetandTake.Services.Abstract;

public interface ICategoryService
{
    Task<List<Category>> GetAllAsync();

    Task<Category> GetByIdAsync(int categoryId);

    Task UpdateAsync(int categoryId, Category category);

    Task CreateAsync(Category category);

    void Delete(int categoryId);
}
