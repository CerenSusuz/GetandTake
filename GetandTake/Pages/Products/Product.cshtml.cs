using GetandTake.Configuration;
using GetandTake.Models.DTOs.ListDTO;
using GetandTake.Services.Abstract;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GetandTake.Pages.Products;

public class ProductModel : PageModel
{
    private readonly IProductService _productService;
    private readonly AppSettings _appSettings;
    private readonly ILogger _logger;

    public IEnumerable<ProductsDTO> Products { get; private set; }

    public int AmountOfProduct { get; private set; }

    public ProductModel
        (
        IProductService productService,
        AppSettings appSettings,
        ILogger<ProductModel> logger
        )
    {
        _productService = productService;
        _appSettings = appSettings;
        _logger = logger;
    }

    public async Task OnGetAsync()
    {
        _logger.LogInformation("Products process start at {DT}", 
            DateTime.UtcNow.ToLongTimeString());

        AmountOfProduct = _appSettings.Products.MaximumAmount;
        Products = await _productService.GetByMaxAmountOfAsync(AmountOfProduct);
    }
}
