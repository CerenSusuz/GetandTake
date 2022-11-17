using GetandTake.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GetandTake.Pages.Categories;

public class CategoryModel : PageModel
{
    private readonly ILogger _logger;

    public CategoryModel(
        ILogger<Category> logger)
    {
        _logger = logger;
    }
    public void OnGet()
    {
        _logger.LogInformation("Categories process start {DT}", 
            DateTime.UtcNow.ToShortTimeString());
    }
}
