using GetandTake.Models.DTOs.ListDTO;
using GetandTake.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace GetandTake.Controller;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IProductService productService;
    public ProductController(IProductService _productService)
    {
        productService = _productService;
    }

    [HttpGet("productlist")]
    public async Task<List<ProductsDTO>> ProductList()
    {
        var productList = await productService.GetAllAsync();
        return productList;

    }
    [HttpGet("getproductbyid")]
    public async Task<ProductsDTO> GetProductById(int id)
    {
        return await productService.GetByIdAsync(id);
    }
}
