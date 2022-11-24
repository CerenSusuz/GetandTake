using GetandTake.Business.Services.Abstract;
using GetandTake.Configuration.Settings;
using GetandTake.Models.DTOs.ListDTO;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SmartBreadcrumbs.Attributes;

namespace GetandTake.Pages.Products;

[Breadcrumb("Products", FromPage = typeof(IndexModel))]
public class ProductModel : PageModel
{
    private readonly IProductService _productService;
    private readonly AppSettings _appSettings;
    private readonly ILogger _logger;

    public IEnumerable<ProductResponse> Products { get; private set; }

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

    public async Task OnGet()
    {
        _logger.LogInformation("Products process start at {DT}",
            DateTime.UtcNow.ToLongTimeString());

        AmountOfProduct = _appSettings.Products.MaximumAmount;
        Products = await _productService.GetByMaxAmountOfAsync(AmountOfProduct);
    }
}