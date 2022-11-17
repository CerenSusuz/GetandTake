using GetandTake.Models;
using GetandTake.Models.DTOs.BaseDTO;
using GetandTake.Services.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GetandTake.Pages.Products;

//[Authorize]
public class CreateModel : PageModel
{
    private readonly IProductService _productService;
    private readonly ICategoryService _categoryService;
    private readonly ISupplierService _supplierService;

    public IEnumerable<Category> Categories { get; private set; }

    public IEnumerable<Supplier> Suppliers { get; private set; }

    [BindProperty]
    public ProductDTO ProductDTO { get; set; }

    public CreateModel(
        IProductService productService,
        ICategoryService categoryService,
        ISupplierService supplierService)
    {
        _productService = productService;
        _categoryService = categoryService;
        _supplierService = supplierService;
    }

    public async Task OnGetAsync()
    {
        Categories = await _categoryService.GetAllAsync();
        Suppliers = await _supplierService.GetAllAsync();
    }

    public async Task<IActionResult> OnPostCreateAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }
        await _productService.CreateAsync(ProductDTO);

        return RedirectToPage("Product");
    }
}

