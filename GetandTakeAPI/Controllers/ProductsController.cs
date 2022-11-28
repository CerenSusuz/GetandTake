using GetandTake.Business.Services.Abstract;
using GetandTake.Models.DTOs.DetailDTO;
using GetandTake.Models.DTOs.ResponseDTO;
using Microsoft.AspNetCore.Mvc;

namespace GetandTakeAPI.Controllers;

/// <summary>
/// Products controller.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;

    /// <summary>
    /// Initializes a new instance of the <see cref="ProductsController"/> class
    /// </summary>
    /// <param name="productService">to connection with Product application logic</param>
    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    /// <summary>
    /// Gets All Products.
    /// </summary>
    /// <returns>
    /// A <see cref="Task"/> representing the asynchronous operation with List of <see cref="ProductResponse"/>
    /// </returns>
    [HttpGet(Name = nameof(GetAllProductsAsync))]
    public async Task<ActionResult<List<ProductResponse>>> GetAllProductsAsync()
    {
        var products = await _productService.GetAllAsync();

        if (products == null)
        {
            return BadRequest();
        }

        return products;
    }

    /// <summary>
    /// Returns information about Product by id.
    /// </summary>
    ///     /// <remarks>
    /// Sample request:
    ///
    ///     GET / Products/id/{id}
    ///     {
    ///         "id": 0
    ///     }
    ///
    /// </remarks>
    /// <param name="id">to find selected product by Product identifier</param>
    /// <returns>
    /// A <see cref="Task"/> representing the asynchronous operation with <see cref="ProductResponse"/>
    /// </returns>
    /// <response code="200"> Product has been found.</response>
    /// <response code="404"> Unable to find product.</response>
    [HttpGet("id/{id:int}")]
    [ProducesResponseType(typeof(ProductResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ProductResponse>> GetProductByIdAsync(int id)
    {
        var product = await _productService.GetByIdAsync(id);

        if (product == null)
        {
            return BadRequest();
        }

        return product;
    }

    /// <summary>
    /// Creates a Product.
    /// </summary>
    /// <param name="product"><see cref="ProductDetail"/></param>
    /// <returns>    
    /// A <see cref="Task"/> representing the asynchronous operation with <see cref="ProductDetail"/>
    /// </returns>
    /// <remarks>
    /// Sample request:
    ///
    ///     POST / Products
    ///     {
    ///         "productName": "string",
    ///         "quantityPerUnit": "string",
    ///         "unitPrice": 0,
    ///         "unitsInStock": 0,
    ///         "unitsOnOrder": 0,
    ///         "reorderLevel": 0,
    ///         "discontinued": true,
    ///         "categoryId": 0,
    ///         "supplierId": 0
    ///     }
    ///
    /// </remarks>
    /// <response code="201">Returns the newly created ProductDetail</response>
    /// <response code="500">Unable to create product due to internal issues.</response>
    /// <response code="400">If the item is null</response>
    [HttpPost]
    [ProducesResponseType(typeof(ProductDetail), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<ProductDetail>> CreateAsync(ProductDetail product)
    {
        await _productService.CreateAsync(product);

        return product;
    }

    /// <summary>
    /// Updates Product.
    /// </summary>    
    /// <param name="id">to find selected product by Product identifier</param>
    /// <param name="product"><see cref="ProductDetail"/></param>
    /// <returns>
    /// A <see cref="Task"/> representing the asynchronous operation with <see cref="ProductDetail"/>
    /// </returns>
    /// <remarks>
    /// Sample request:
    ///
    ///     PUT / Products/id/{id}
    ///     {
    ///         "id": 0,
    ///         "productName": "string",
    ///         "quantityPerUnit": "string",
    ///         "unitPrice": 0,
    ///         "unitsInStock": 0,
    ///         "unitsOnOrder": 0,
    ///         "reorderLevel": 0,
    ///         "discontinued": true,
    ///         "categoryId": 0,
    ///         "supplierId": 0
    ///      }
    ///
    /// </remarks>
    /// <response code="201">Returns the newly updated Product.</response>
    /// <response code="404">Unable to find product.</response>
    /// <response code="500">Unable to update product due to internal issues.</response>
    [HttpPut("id/{id:int}")]
    [ProducesResponseType(typeof(ProductDetail), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<ProductDetail>> UpdateAsync(int id, ProductDetail product)
    {
        var findProduct = _productService.GetByIdAsync(id);

        if (findProduct.Result == null)
        {
            return BadRequest(findProduct);
        }
        await _productService.UpdateAsync(id, product);

        return product;
    }

    /// <summary>
    /// Deletes specific product from database.
    /// </summary>
    /// <param name="id">to find selected product by Product identifier</param>
    /// <remarks>
    /// Sample request:
    ///
    ///     DELETE / Products/id/{id}
    ///     {
    ///         "id": 0,
    ///     }
    ///
    /// </remarks>
    /// <response code="204">Product has been removed from database.</response>
    /// <response code="404">Unable to find product.</response>
    /// <returns>status ok message</returns>
    [HttpDelete("id/{id:int}")]
    [ProducesResponseType(typeof(void), StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
    public IActionResult Delete(int id)
    {
        var findProduct = _productService.GetByIdAsync(id);

        if (findProduct.Result == null)
        {
            return BadRequest(findProduct);
        }

        _productService.Delete(id);

        return Ok(findProduct.Result);
    }
}