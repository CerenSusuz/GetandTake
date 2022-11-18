using GetandTake.Models;
using GetandTake.Services.Abstract;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GetandTake.Pages.Categories;

public class CategoryModel : PageModel
{
    private readonly ICategoryService _categoryService;
    private readonly ILogger _logger;

    public IEnumerable<Category> Categories { get; private set; }

    public CategoryModel(
        ICategoryService categoryService,
        ILogger<Category> logger)
    {
        _categoryService = categoryService;
        _logger = logger;
    }
    public async Task OnGet()
    {
        _logger.LogInformation("Categories process start {DT}",
            DateTime.UtcNow.ToShortTimeString());

        Categories = await _categoryService.GetAllAsync();
    }
}