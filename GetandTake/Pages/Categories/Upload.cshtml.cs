using GetandTake.Models;
using GetandTake.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GetandTake.Pages.Categories;

public class UploadModel : PageModel
{
    private readonly ICategoryService _categoryService;
    private readonly ICategoryImageService _categoryImageService;

    public UploadModel(ICategoryService categoryService, ICategoryImageService categoryImageService)
    {
        _categoryService = categoryService;
        _categoryImageService = categoryImageService;
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
        await _categoryImageService.Add(Upload, id);

        return RedirectToPage("Category");
    }
}
