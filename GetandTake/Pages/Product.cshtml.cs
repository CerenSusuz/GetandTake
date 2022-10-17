using GetandTake.Configuration;
using GetandTake.Models.DTOs.ListDTO;
using GetandTake.Services.Abstract;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GetandTake.Pages;

public class ProductModel : PageModel
{

    private readonly IProductService _productService;

    private readonly IConfiguration Configuration;

    public IEnumerable<ProductsDTO> Products { get; private set; }

    public int AmountOfProduct { get; private set; }

    public ProductModel(IProductService productService, IConfiguration configuration)
    {
        _productService = productService;
        Configuration = configuration;
    }

    public void OnGet()
    {
        AmountOfProduct = Convert.ToInt32(Configuration.GetSection("MaximumAmountOfProduct").Value);
        Products = _productService.GetByMaximumAmount(AmountOfProduct);
    }
}
