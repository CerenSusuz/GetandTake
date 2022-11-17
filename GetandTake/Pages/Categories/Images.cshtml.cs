using GetandTake.Models;
using GetandTake.Services.Abstract;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SmartBreadcrumbs.Attributes;

namespace GetandTake.Pages.Categories
{
    [Breadcrumb("Images", FromPage = typeof(CategoryModel))]
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
}
