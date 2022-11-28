using GetandTake.Business.Services.Abstract;
using GetandTake.Models.DTOs.DetailDTO;
using GetandTake.Models.DTOs.ResponseDTO;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace GetandTakeAPI.Controllers;

/// <summary>
/// Categories controller.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    /// <summary>
    /// Initializes a new instance of the <see cref="CategoriesController"/> class.
    /// </summary>
    /// <param name="categoryService">to coneection with Category application logic</param>
    public CategoriesController(ICategoryService categoryService) => _categoryService = categoryService;

    /// <summary>
    /// Gets all categories.
    /// </summary>
    /// <remarks>
    /// Sample response:
    ///
    ///     GET / categories
    ///     {
    ///       "categoryID": 1,
    ///       "categoryName": "Beverages",
    ///       "description": "Soft drinks, coffees, teas, beers, and ales",
    ///       "imagePath": "\\uploads\\beverages.png"  
    ///     }
    ///
    /// </remarks>
    /// <returns>
    /// A <see cref="Task"/> representing the asynchronous operation with list of <see cref="CategoryResponse"/>
    /// </returns>
    /// <response code="200"> Category List has been found.</response>
    /// <response code="404"> Unable to find product.</response>
    [HttpGet(Name = nameof(GetAllCategoriesAsync))]
    [ProducesResponseType(typeof(CategoryResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<List<CategoryResponse>>> GetAllCategoriesAsync()
    {
        var categories = await _categoryService.GetAllAsync();

        if (categories == null)
        {
            return NotFound();
        }

        return categories;
    }

    /// <summary>
    /// Returns information about category by id.
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     GET / categories/id/{id}
    ///     {
    ///       "id": 10
    ///     }
    ///
    /// </remarks>
    /// <param name="id">Category identifier</param>
    /// <returns>
    /// A <see cref="Task"/> representing the asynchronous operation with <see cref="CategoryResponse"/>
    /// </returns>
    /// <response code="200"> Category has been found.</response>
    /// <response code="404"> Unable to find category.</response>
    [HttpGet("id/{id:int}")]
    [ProducesResponseType(typeof(CategoryResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CategoryResponse>> GetByIdAsync(int id)
    {
        var category = await _categoryService.GetByIdAsync(id);

        if (category == null)
        {
            return NotFound();
        }

        return category;
    }

    /// <summary>
    /// Creates a category.
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     POST / categories
    ///     {
    ///         "categoryName": "Beverages",
    ///         "description": "Soft drinks, coffees, teas, beers, and ales",
    ///         "imagePath": "\\uploads\\beverages.png"
    ///     }
    ///
    /// </remarks>
    /// <param name="category"><see cref="CategoryDetail"/></param>
    /// <returns>    
    /// A <see cref="Task"/> representing the asynchronous operation with <see cref="CategoryDetail"/>
    /// </returns>
    /// <response code="201">Returns the newly created category detail</response>
    /// <response code="404">Unable to find category.</response>
    /// <response code="500">Unable to create category due to internal issues.</response>
    [HttpPost]
    [ProducesResponseType(typeof(CategoryDetail), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<CategoryDetail>> CreateAsync(CategoryDetail category)
    {
        await _categoryService.CreateAsync(category);

        return category;
    }

    /// <summary>
    /// Updates a category.
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     PUT / categories/id/{id}
    ///     
    ///     {
    ///         "id": 1,
    ///         "categoryName": "Beverages",
    ///         "description": "Soft drinks, coffees, teas, beers, and ales",
    ///         "imagePath": "\\uploads\\beverages.png"
    ///     }
    ///
    /// </remarks>
    /// <param name="id">Category identifier</param>
    /// <param name="category"> <see cref="CategoryDetail"/> </param>
    /// <returns>
    /// A <see cref="Task"/> representing the asynchronous operation with <see cref="CategoryDetail"/>
    /// </returns>
    /// <response code="201">Returns the newly updated category detail.</response>
    /// <response code="404">Unable to find category.</response>
    /// <response code="500">Unable to update category due to internal issues.</response>
    [HttpPut("id/{id:int}")]
    [ProducesResponseType(typeof(CategoryDetail), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<CategoryDetail>> UpdateAsync(int id, CategoryDetail category)
    {
        var foundCategory = _categoryService.GetByIdAsync(id);

        if (foundCategory.Result == null)
        {
            return NotFound();
        }

        await _categoryService.UpdateAsync(id, category);

        return category;
    }

    /// <summary>
    /// Deletes specific category from database.
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     DELETE / categories/id/{id}
    ///     {
    ///         "id": 1,
    ///     }
    ///
    /// </remarks>
    /// <param name="id">Category identifier</param>
    /// <response code="204">Category has been removed from database.</response>
    /// <response code="404">Unable to find category.</response>
    /// <returns>status ok message</returns>
    [HttpDelete("id/{id:int}")]
    [ProducesResponseType(typeof(void), StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
    public IActionResult Delete(int id)
    {
        var foundCategory = _categoryService.GetByIdAsync(id);

        if (foundCategory.Result == null)
        {
            return NotFound();
        }

        _categoryService.Delete(id);

        return Ok("deleted process success");
    }

    /// <summary>
    /// Returns information about image by category id.
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     GET / categories/image/id/{id}
    ///     
    ///     {
    ///         "id": 1
    ///     }
    ///
    /// </remarks>
    /// <param name="id">Category identifier</param>
    /// <returns>
    /// A <see cref="Task"/> representing the asynchronous operation with <see cref="CategoryDetail.ImagePath"/>
    /// </returns>
    /// <response code="200"> Image has been found.</response>
    /// <response code="404"> Unable to find Image.</response>
    [HttpGet("image/id/{id:int}")]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<string>> GetImageByCategoryId(int id)
    {
        var foundCategory = _categoryService.GetByIdAsync(id);

        if (foundCategory.Result == null)
        {
            return NotFound();
        }

        return await _categoryService.GetImageByCategoryIdAsync(id);
    }

    /// <summary>
    /// Partial updates a category.
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     PATCH / categories/id/{id}
    ///     
    ///     {
    ///         "id": 1,
    ///         "operationType": replace,
    ///         "path": "/imagePath",
    ///         "op": "replace",
    ///         "from": "\\uploads\\beverages.png",
    ///         "value": "\\uploads\\condiments.png"
    ///     }
    ///
    /// </remarks>
    /// <param name="id">Category identifier</param>
    /// <param name="categoryPatchDocument">to partial update category<see cref="CategoryDetail"/></param>
    /// <returns>
    /// A <see cref="Task"/> representing the asynchronous operation with <see cref="CategoryResponse"/>
    /// </returns>
    /// <response code="201">Returns the newly updated Category</response>
    /// <response code="404">Unable to find Category.</response>
    /// <response code="500">Unable to update Category due to internal issues.</response>
    [HttpPatch("id/{id:int}")]
    [ProducesResponseType(typeof(CategoryResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<CategoryResponse>> PatchUpdateAsync(int id,
        [FromBody] JsonPatchDocument<CategoryDetail> categoryPatchDocument)
    {
        if (categoryPatchDocument == null)
        {
            return NotFound();
        }

        return await _categoryService.PatchUpdateAsync(id, categoryPatchDocument);
    }
}