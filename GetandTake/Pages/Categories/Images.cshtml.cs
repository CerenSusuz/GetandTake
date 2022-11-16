using GetandTake.Models;
using GetandTake.Services.Abstract;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GetandTake.Pages.Categories;

public class ImagesModel : PageModel
{
    private readonly ICategoryService _categoryService;

    public IEnumerable<Category> Categories { get; private set; }

    public ImagesModel(
        ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    public async Task OnGet()
    {
        Categories = await _categoryService.GetAllAsync();
    }
}
