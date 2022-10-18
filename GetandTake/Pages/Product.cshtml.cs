using GetandTake.Configuration;
using GetandTake.Models.DTOs.ListDTO;
using GetandTake.Services.Abstract;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GetandTake.Pages;

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

    public void OnGet()
    {
        AmountOfProduct = _appSettings.Products.MaximumAmount;
        Products = _productService.GetByMaximumAmount(AmountOfProduct);
    }
}
