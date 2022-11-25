using GetandTake.Business.Services.Abstract;
using GetandTake.Models.DTOs.DetailDTO;
using GetandTake.Models.DTOs.ResponseDTO;
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

    [HttpGet(Name = nameof(GetAllProducts))]
    public async Task<ActionResult<List<ProductResponse>>> GetAllProducts()
    {
        var products = await _productService.GetAllAsync();

        if (products == null)
        {
            return BadRequest();
        }

        return products;
    }

    [HttpGet("id/{id:int}")]
    public async Task<ActionResult<ProductResponse>> GetProductByIdAsync(int id)
    {
        var product = await _productService.GetByIdAsync(id);

        if (product == null)
        {
            return BadRequest();
        }

        return product;
    }

    [HttpPost]
    public async Task<ActionResult<ProductDetail>> CreateAsync(ProductDetail product)
    {
        await _productService.CreateAsync(product);

        return product;
    }

    [HttpPut("id/{id:int}")]
    public async Task<ActionResult<ProductDetail>> UpdateAsync(int id, ProductDetail product)
    {
        await _productService.UpdateAsync(id, product);

        return product;
    }

    [HttpDelete("id/{id:int}")]
    public IActionResult Delete(int id)
    {
        _productService.Delete(id);

        return Ok("deleted process success");
    }
}