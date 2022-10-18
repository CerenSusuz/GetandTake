using GetandTake.Configuration;
using GetandTake.Models;
using GetandTake.Models.DTOs.BaseDTO;
using GetandTake.Models.DTOs.ListDTO;
using GetandTake.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GetandTake.Pages.Products
{
    public class CreateModel : PageModel
    {

        private readonly IProductService _productService;

        private readonly ICategoryService _categoryService;

        public IEnumerable<Category> Categories { get; private set; }
        public ProductDTO ProductDTO { get; private set; }

        public CreateModel(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        public void OnGet()
        {
            Categories = _categoryService.GetAll();
        }

        public async Task<IActionResult> OnPost(ProductDTO productDTO)
        {
            await _productService.CreateAsync(productDTO);
            return RedirectToPage("Product");
        }
    }
}
