using GetandTake.Business.Services.Abstract;
using GetandTake.Models.DTOs.ListDTO;
using Microsoft.AspNetCore.Mvc;

namespace GetandTakeAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<ActionResult<List<ProductsDTO>>> GetAllProducts()
    {
        var products = await _productService.GetAllAsync();

        return Ok(products);
    }

    [HttpGet("id/{id:int}")]
    public async Task<ProductsDTO> GetProductByIdAsync(int id)
    {
        return await _productService.GetByIdAsync(id);
    }
}