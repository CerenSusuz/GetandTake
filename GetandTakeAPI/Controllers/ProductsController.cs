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

        if (products == null)
        {
            return BadRequest();
        }

        return products;
    }

    [HttpGet("id/{id:int}")]
    public async Task<ActionResult<ProductsDTO>> GetProductByIdAsync(int id)
    {
        var product = await _productService.GetByIdAsync(id);

        if (product == null)
        {
            return BadRequest();
        }

        return product;
    }
}