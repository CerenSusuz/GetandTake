using GetandTake.Core.Models;
using GetandTake.Models;
using GetandTake.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GetandTake.Pages.Categories
{
    public class UploadModel : PageModel
    {
        private readonly ICategoryService _categoryService;

        [BindProperty]
        public FileUpload FileUpload { get; set; }

        public UploadModel(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public Category Category { get; set; }

        public async Task OnGet(int id)
        {
            Category = await _categoryService.GetByIdAsync(id);
        }

        public async Task<IActionResult> OnPostUploadAsync()
        {
            using (var memoryStream = new MemoryStream())
            {
                await FileUpload.FormFile.CopyToAsync(memoryStream);

                // Upload the file if less than 2 MB
                if (memoryStream.Length < 2097152)
                {
                    var file = new Category()
                    {
                        CategoryName = Category.CategoryName,
                        Description = Category.Description,
                        Picture = memoryStream.ToArray()
                    };
                    await _categoryService.UpdateAsync(Category.CategoryID, Category);
                }
                else
                {
                    ModelState.AddModelError("File", "The file is too large.");
                }
            }

            return Page();
        }
    }
}
