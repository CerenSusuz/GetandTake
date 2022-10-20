using GetandTake.Configuration;
using GetandTake.Models.DTOs.ListDTO;
using GetandTake.Services.Abstract;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GetandTake.Pages.Products;

public class ProductModel : PageModel
{
    private readonly IProductService _productService;
    private readonly AppSettings _appSettings;

    public IEnumerable<ProductsDTO> Products { get; private set; }

    public int AmountOfProduct { get; private set; }

    public ProductModel
        (
        IProductService productService,
        AppSettings appSettings
        )
    {
        _productService = productService;
        _appSettings = appSettings;
    }

    public async Task OnGet()
    {
        AmountOfProduct = _appSettings.Products.MaximumAmount;
        Products = await _productService.GetByMaxAmountOfAsync(AmountOfProduct);
    }
}
