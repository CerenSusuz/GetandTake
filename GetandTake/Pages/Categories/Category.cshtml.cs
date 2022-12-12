using GetandTake.Business.Services.Abstract;
using GetandTake.Models;
using GetandTake.Models.DTOs.ResponseDTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SmartBreadcrumbs.Attributes;

namespace GetandTake.Pages.Categories;

[AllowAnonymous]
[Breadcrumb("Categories", FromPage = typeof(IndexModel))]
public class CategoryModel : PageModel
{
    private readonly ICategoryService _categoryService;
    private readonly ILogger _logger;

    public IEnumerable<CategoryResponse> Categories { get; private set; }

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