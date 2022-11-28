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
    /// Initializes a new instance of the <see cref="CategoriesController"/> class
    /// </summary>
    /// <param name="categoryService">to coneection with Category application logic</param>
    public CategoriesController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    /// <summary>
    /// Gets All Categories
    /// </summary>
    /// <returns>
    /// A <see cref="Task"/> representing the asynchronous operation with List of <see cref="CategoryResponse"/>
    /// </returns>
    [HttpGet(Name = nameof(GetAllCategoriesAsync))]
    public async Task<ActionResult<List<CategoryResponse>>> GetAllCategoriesAsync()
    {
        var categories = await _categoryService.GetAllAsync();

        if (categories == null)
        {
            return BadRequest();
        }

        return categories;
    }

    /// <summary>
    /// Returns information about Category by id.
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     POST / Categories/id/{id}
    /// {
    ///       "id":0
    /// }
    ///
    /// </remarks>
    /// <param name="id">to take selected category by Category identifier</param>
    /// <returns>
    /// A <see cref="Task"/> representing the asynchronous operation with <see cref="CategoryResponse"/>
    /// </returns>
    /// <response code="200"> Category has been found.</response>
    /// <response code="404"> Unable to find Category.</response>
    [HttpGet("id/{id:int}")]
    [ProducesResponseType(typeof(CategoryResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CategoryResponse>> GetCategoryByIdAsync(int id)
    {
        var category = await _categoryService.GetByIdAsync(id);

        if (category == null)
        {
            return BadRequest();
        }

        return category;
    }

    /// <summary>
    /// Creates a Category
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     POST / Categories
    ///     {
    ///         "categoryName": "string",
    ///         "description": "string",
    ///         "imagePath": "string"
    ///     }
    ///
    /// </remarks>
    /// <param name="category"><see cref="CategoryDetail"/></param>
    /// <returns>    
    /// A <see cref="Task"/> representing the asynchronous operation with <see cref="CategoryDetail"/>
    /// </returns>
    /// <response code="201">Returns the newly created CategoryDetail</response>
    /// <response code="500">Unable to create Category due to internal issues.</response>
    /// <response code="400">If the item is null</response>
    [HttpPost]
    [ProducesResponseType(typeof(CategoryDetail), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<CategoryDetail>> CreateAsync(CategoryDetail category)
    {
        await _categoryService.CreateAsync(category);

        return category;
    }

    /// <summary>
    /// Updates a Category
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     PUT / Categories/id/{id}
    ///     
    /// {
    ///     "id":0,
    ///     "categoryName": "string",
    ///     "description": "string",
    ///     "imagePath": "string"
    /// }
    ///
    /// </remarks>
    /// <param name="id">to find selected category by category identifier</param>
    /// <param name="category"> <see cref="CategoryDetail"/> </param>
    /// <returns>
    /// A <see cref="Task"/> representing the asynchronous operation with <see cref="CategoryDetail"/>
    /// </returns>
    /// <response code="201">Returns the newly updated Category.</response>
    /// <response code="404">Unable to find Category.</response>
    /// <response code="500">Unable to update Category due to internal issues.</response>
    [HttpPut("id/{id:int}")]
    [ProducesResponseType(typeof(CategoryDetail), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<CategoryDetail>> UpdateAsync(int id, CategoryDetail category)
    {
        await _categoryService.UpdateAsync(id, category);

        return category;
    }

    /// <summary>
    /// Deletes specific Category from database
    /// </summary>
    /// <remarks>
    /// 
    ///  Sample request:
    ///
    ///     Delete /Categories/id/{id}
    ///     {
    ///        "id": 0
    ///     }
    ///     
    /// </remarks>
    /// <param name="id">to delete selected category by category identifier</param>
    /// <response code="204">Category has been removed from database.</response>
    /// <response code="404">Unable to find Category.</response>
    /// <returns>status ok message</returns>
    [HttpDelete("id/{id:int}")]
    [ProducesResponseType(typeof(void), StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
    public IActionResult Delete(int id)
    {
        _categoryService.Delete(id);

        return Ok("deleted process success");
    }

    /// <summary>
    /// Returns information about Image by Category Id.
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     POST / Categories/Image/id/{id}
    ///     
    ///     {
    ///         "id":0
    ///     }
    ///
    /// </remarks>
    /// <param name="id">to find Image by Category Identifier</param>
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
        var imageUrl = await _categoryService.GetImageByCategoryIdAsync(id);

        return imageUrl;
    }

    /// <summary>
    /// Partial Updates a Category
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     POST / Categories/id/{id}
    ///     
    ///     {
    ///         "id":0,
    ///         "operationType": 0,
    ///         "path": "string",
    ///         "op": "string",
    ///         "from": "string",
    ///         "value": "string"
    ///     }
    ///
    /// </remarks>
    /// <param name="id">to find selected category by category identifier</param>
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
            return BadRequest();
        }

        return await _categoryService.PatchUpdateAsync(id, categoryPatchDocument);
    }
}