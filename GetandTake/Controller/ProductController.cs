using GetandTake.Models.DTOs.BaseDTO;
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

    [HttpGet]
    public async Task<List<ProductsDTO>> ProductList()
    {
        var productList = await productService.GetAllAsync();

        return productList;

    }

    [HttpGet("id/{id:int}")]
    public async Task<ProductsDTO> GetProductByIdAsync(int id)
    {
        return await productService.GetByIdAsync(id);
    }
}
