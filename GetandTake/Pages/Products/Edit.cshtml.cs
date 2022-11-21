using GetandTake.Business.Services.Abstract;
using GetandTake.Models;
using GetandTake.Models.DTOs.BaseDTO;
using GetandTake.Models.DTOs.ListDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GetandTake.Pages.Products;

public class EditModel : PageModel
{
    private readonly IProductService _productService;
    private readonly ICategoryService _categoryService;
    private readonly ISupplierService _supplierService;

    public ProductsDTO ProductDTO { get; set; }

    [BindProperty]
    public ProductDTO Product { get; set; }

    public IEnumerable<Category> Categories { get; private set; }

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