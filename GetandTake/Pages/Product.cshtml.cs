using GetandTake.Configuration;
using GetandTake.Models.DTOs.ListDTO;
using GetandTake.Services.Abstract;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GetandTake.Pages;

public class ProductModel : PageModel
{

    private readonly IProductService _productService;

    private readonly ProductsSettings _productsSettings;

    public IEnumerable<ProductsDTO> Products { get; private set; }

    public int AmountOfProduct { get; private set; }

    public ProductModel
        (
        IProductService productService,
        ProductsSettings productsSettings
        )
    {
        _productService = productService;
        _productsSettings = productsSettings;
    }

    public void OnGet()
    {
        AmountOfProduct = _productsSettings.MaximumAmount;
        Products = _productService.GetByMaximumAmount(AmountOfProduct);
    }
}
