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
    public IFormFile Upload { get; set; }

    [BindProperty]
    public Category Category { get; set; }

    public async Task OnGet(int id)
    {
        Category = await _categoryService.GetByIdAsync(id);
    }

    public async Task<IActionResult> OnPost(int id)
    {
        Category cat = await _categoryService.GetByIdAsync(id);
        if (Upload.Length > 0)
        {
            using (var stream = new MemoryStream())
            {
                Upload.CopyTo(stream);
                Category category = new()
                {
                    CategoryName = cat.CategoryName,
                    Description = cat.Description,
                    Picture = stream.ToArray()
                };
                await _categoryService.UpdateAsync(id, category);
            };
            return RedirectToPage("Category");
        }
        return Page();
    }
}
