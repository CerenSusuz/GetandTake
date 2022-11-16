using GetandTake.Business.Services.Abstract;
using GetandTake.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GetandTake.Pages.Categories
{
    public class ImageModel : PageModel
    {
        private readonly ICategoryService _categoryService;

        public Category Category { get; private set; }

        public ImageModel(
            ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task OnGet(int id)
        {
            Category = await _categoryService.GetByIdAsync(id);
        }
    }
}
