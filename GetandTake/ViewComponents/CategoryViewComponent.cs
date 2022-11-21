using GetandTake.Business.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace GetandTake.ViewComponents;

public class CategoryViewComponent : ViewComponent
{
    private readonly ICategoryService _categoryService;

    public CategoryViewComponent(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var categories = await _categoryService.GetAllAsync();

        return View(categories);
    }
}