using GetandTake.Models;
using GetandTake.Models.DTOs.BaseDTO;
using GetandTake.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GetandTake.Pages.Products;

[BindProperties]
public class CreateModel : PageModel
{

    private readonly IProductService _productService;

    private readonly ICategoryService _categoryService;

    private readonly ISupplierService _supplierService;

    public IEnumerable<Category> Categories { get; private set; }

    public IEnumerable<Supplier> Suppliers { get; private set; }

    public ProductDTO ProductDTO { get; set; }

    public CreateModel
        (
        IProductService productService,
        ICategoryService categoryService,
        ISupplierService supplierService
        )
    {
        _productService = productService;
        _categoryService = categoryService;
        _supplierService = supplierService;
    }

    public void OnGet()
    {
        Categories = _categoryService.GetAll();
        Suppliers = _supplierService.GetAll();
    }

    public async Task<IActionResult> OnPost(ProductDTO productDTO)
    {
        await _productService.CreateAsync(productDTO);
        return RedirectToPage("Product");
    }
}

