using GetandTake.Business.Services.Abstract;
using GetandTake.Models;
using GetandTake.Models.DTOs.DetailDTO;
using GetandTake.Models.DTOs.ResponseDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SmartBreadcrumbs.Attributes;

namespace GetandTake.Pages.Products;

[Breadcrumb("Edit Product", FromPage = typeof(ProductModel))]
public class EditModel : PageModel
{
    private readonly IProductService _productService;
    private readonly ICategoryService _categoryService;
    private readonly ISupplierService _supplierService;

    public ProductResponse ProductDTO { get; set; }

    [BindProperty]
    public ProductDetail Product { get; set; }

    public IEnumerable<CategoryResponse> Categories { get; private set; }

    public IEnumerable<Supplier> Suppliers { get; private set; }

    public EditModel(
        IProductService productService,
        ICategoryService categoryService,
        ISupplierService supplierService)
    {
        _productService = productService;
        _categoryService = categoryService;
        _supplierService = supplierService;
    }

    public async Task OnGet(int id)
    {
        ProductDTO = await _productService.GetByIdAsync(id);
        Categories = await _categoryService.GetAllAsync();
        Suppliers = await _supplierService.GetAllAsync();
    }

    public async Task<IActionResult> OnPost(int id)
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }
        await _productService.UpdateAsync(id, Product);

        return RedirectToPage("Product");
    }
}