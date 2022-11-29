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
    public ProductsController(IProductService productService) => _productService = productService;

    /// <summary>
    /// Gets all products.
    /// </summary>
    /// <remarks>
    /// Sample response:
    ///
    ///     GET / products/id/{id}
    ///     {
    ///       "productID": 1,
    ///       "productName": "Chai",
    ///       "quantityPerUnit": "10 boxes x 20 bags",
    ///       "unitPrice": 18,  
    ///       "unitsInStock": 39,  
    ///       "unitsOnOrder": 0,  
    ///       "reorderLevel": 10,  
    ///       "discontinued": false,  
    ///       "category": "Beverages",  
    ///       "supplier": "Exotic Liquids",  
    ///     }
    ///
    /// </remarks>
    /// <returns>
    /// A <see cref="Task"/> representing the asynchronous operation with List of <see cref="ProductResponse"/>
    /// </returns>
    /// <response code="200"> Product List has been found.</response>
    /// <response code="404"> Unable to find product.</response>
    [HttpGet(Name = nameof(GetAllProductsAsync))]
    [ProducesResponseType(typeof(CategoryResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<List<ProductResponse>>> GetAllProductsAsync()
    {
        var products = await _productService.GetAllAsync();

        if (products == null)
        {
            return NotFound();
        }

        return products;
    }

    /// <summary>
    /// Returns information about product by id.
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     GET / products/id/{id}
    ///     {
    ///         "id": 1
    ///     }
    ///
    /// </remarks>
    /// <param name="id">Product identifier</param>
    /// <returns>
    /// A <see cref="Task"/> representing the asynchronous operation with <see cref="ProductResponse"/>
    /// </returns>
    /// <response code="200"> Product has been found.</response>
    /// <response code="404"> Unable to find product.</response>
    [HttpGet("id/{id:int}")]
    [ProducesResponseType(typeof(ProductResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ProductResponse>> GetByIdAsync(int id)
    {
        var product = await _productService.GetByIdAsync(id);

        if (product == null)
        {
            return NotFound();
        }

        return product;
    }

    /// <summary>
    /// Creates a product.
    /// </summary>
    /// <param name="product"><see cref="ProductDetail"/></param>
    /// <returns>    
    /// A <see cref="Task"/> representing the asynchronous operation with <see cref="ProductDetail"/>
    /// </returns>
    /// <remarks>
    /// Sample request:
    ///
    ///     POST / products/id/{id}
    ///     {
    ///       "productID": 1,
    ///       "productName": "Chai",
    ///       "quantityPerUnit": "10 boxes x 20 bags",
    ///       "unitPrice": 18,  
    ///       "unitsInStock": 39,  
    ///       "unitsOnOrder": 0,  
    ///       "reorderLevel": 10,  
    ///       "discontinued": false,  
    ///       "categoryId": 1,  
    ///       "supplierId": 1,  
    ///     }
    ///
    /// </remarks>
    /// <response code="201">Returns the newly created product detail</response>
    /// <response code="404">Unable to find product.</response>
    /// <response code="500">Unable to create product due to internal issues.</response>
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
    /// Updates a product.
    /// </summary>    
    /// <param name="id">Product identifier</param>
    /// <param name="product"><see cref="ProductDetail"/></param>
    /// <returns>
    /// A <see cref="Task"/> representing the asynchronous operation with <see cref="ProductDetail"/>
    /// </returns>
    /// <remarks>
    /// Sample request:
    ///
    ///     PUT / products/id/{id}
    ///     {
    ///       "productID": 1,
    ///       "productName": "Chai",
    ///       "quantityPerUnit": "10 boxes x 20 bags",
    ///       "unitPrice": 18,  
    ///       "unitsInStock": 39,  
    ///       "unitsOnOrder": 0,  
    ///       "reorderLevel": 10,  
    ///       "discontinued": false,  
    ///       "categoryId": 1,  
    ///       "supplierId": 1,  
    ///     }
    ///
    /// </remarks>
    /// <response code="201">Returns the newly updated product.</response>
    /// <response code="404">Unable to find product.</response>
    /// <response code="500">Unable to update product due to internal issues.</response>
    [HttpPut("id/{id:int}")]
    [ProducesResponseType(typeof(ProductDetail), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<ProductDetail>> UpdateAsync(int id, ProductDetail product)
    {
        var foundProduct = _productService.GetByIdAsync(id);

        if (foundProduct.Result == null)
        {
            return NotFound();
        }

        await _productService.UpdateAsync(id, product);

        return product;
    }

    /// <summary>
    /// Deletes specific product from database.
    /// </summary>
    /// <param name="id">Product identifier</param>
    /// <remarks>
    /// Sample request:
    ///
    ///     DELETE / products/id/{id}
    ///     {
    ///         "id": 1,
    ///     }
    ///
    /// </remarks>
    /// <response code="204">Product has been removed from database.</response>
    /// <response code="404">Unable to find product.</response>
    /// <returns>NoContent status code</returns>
    [HttpDelete("id/{id:int}")]
    [ProducesResponseType(typeof(void), StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
    public IActionResult Delete(int id)
    {
        var foundProduct = _productService.GetByIdAsync(id);

        if (foundProduct.Result == null)
        {
            return NotFound();
        }

        _productService.Delete(id);

        return NoContent();
    }
}