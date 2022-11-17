using GetandTake.Models;
using GetandTake.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SmartBreadcrumbs.Attributes;

namespace GetandTake.Pages.Categories;

[Breadcrumb("Upload Image", FromPage = typeof(CategoryModel))]
public class UploadModel : PageModel
{
    private readonly ICategoryService _categoryService;

    public UploadModel(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [BindProperty]
    public IFormFile Upload { get; set; }

    [BindProperty]
    public Category Category { get; set; }

    public async Task OnGet(int id)
    {
        Category = await _categoryService.GetByIdAsync(id);
    }

    public async Task<IActionResult> OnPost(int id)
    {
        await _categoryService.UploadImage(Upload, id);

        return RedirectToPage("Category");
    }
}
