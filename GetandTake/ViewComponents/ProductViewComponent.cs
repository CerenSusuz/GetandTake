using GetandTake.Business.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace GetandTake.ViewComponents;

public class ProductViewComponent : ViewComponent
{
    private readonly IProductService _productService;

    public ProductViewComponent(IProductService productService)
    {
        _productService = productService;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var products = await _productService.GetAllAsync();

        return View(products);
    }
}
