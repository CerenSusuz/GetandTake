using GetandTake.Models;
using GetandTake.Models.DTOs.BaseDTO;
using GetandTake.Models.DTOs.ListDTO;
using GetandTake.Services.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GetandTake.Pages.Products;

//[Authorize]
public class EditModel : PageModel
{
    private readonly IProductService _productService;

    public ProductsDTO ProductDTO { get; set; }

    [BindProperty]
    public ProductDTO Product { get; set; }

    public EditModel(
        IProductService productService)
    {
        _productService = productService;
    }

    public async Task OnGetAsync(int id)
    {
        ProductDTO = await _productService.GetByIdAsync(id);
    }

    public async Task<IActionResult> OnPostUpdateAsync(int id)
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }
        await _productService.UpdateAsync(id, Product);

        return RedirectToPage("Product");
    }
}

