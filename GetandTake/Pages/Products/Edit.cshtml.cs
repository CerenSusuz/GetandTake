using GetandTake.Models;
using GetandTake.Models.DTOs.BaseDTO;
using GetandTake.Models.DTOs.ListDTO;
using GetandTake.Services.Abstract;
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

    public EditModel
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

    public void OnGet(int id)
    {
        ProductDTO = _productService.GetById(id);
        Categories = _categoryService.GetAll();
        Suppliers = _supplierService.GetAll();
    }

    public async Task<IActionResult> OnPost(int id)
    {
        if (ModelState.IsValid)
        {
            await _productService.UpdateAsync(id, Product);

            return RedirectToPage("Product");
        }
        return Page();


    }
}

