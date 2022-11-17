using GetandTake.Models;
using GetandTake.Services.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GetandTake.Pages.Categories;

//[Authorize]
public class EditModel : PageModel
{
    private readonly ICategoryService _categoryService;

    [BindProperty]
    public Category Category { get; set; }

    public EditModel(ICategoryService categoryService) => _categoryService = categoryService;

    public async Task OnGet(int id)
    {
        Category = await _categoryService.GetByIdAsync(id);
    }

    public async Task<IActionResult> OnPost(int id)
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }
        await _categoryService.UpdateAsync(id, Category);

        return RedirectToPage("Category");
    }
}

