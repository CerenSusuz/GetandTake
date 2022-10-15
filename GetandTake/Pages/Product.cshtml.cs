using GetandTake.Models.DTOs.ListDTO;
using GetandTake.Services.Abstracts;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GetandTake.Pages
{
    public class ProductModel : PageModel
    {
        private readonly IProductService _productService;
        public IEnumerable<ProductsDTO> Products { get; private set; }
        public ProductModel(IProductService productService)
        {
            _productService = productService;
        }
        public async Task OnGet()
        {
            Products = await _productService.GetAllAsync();
        }
    }
}
