using GetandTake.Models;
using GetandTake.Services.Abstract;
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
    public IFormFile Image { get; set; }

    [BindProperty]
    public Category Category { get; set; }

    public async Task OnGetAsync(int id)
    {
        Category = await _categoryService.GetByIdAsync(id);
    }

    public async Task<IActionResult> OnPost(int id)
    {
        await _categoryService.UploadImage(Image, id);

        return RedirectToPage("Category");
    }
}
