using GetandTake.Models;
using GetandTake.Models.DTOs.BaseDTO;
using GetandTake.Models.DTOs.ListDTO;

namespace GetandTake.Services.Abstracts
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAllAsync();
        Task<Category> GetAsync(int id);
        Task UpdateAsync(int id, Category category);
        Task InsertAsync(Category dto);
        Task DeleteAsync(int id);
    }
}
