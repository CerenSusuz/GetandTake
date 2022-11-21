using GetandTake.Business.Services.Abstract;
using GetandTake.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SmartBreadcrumbs.Attributes;

namespace GetandTake.Pages.Categories;

[Breadcrumb("Edit Category", FromPage = typeof(CategoryModel))]
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

