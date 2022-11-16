using GetandTake.Business.Services.Abstract;
using GetandTake.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GetandTake.Pages.Categories;

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
