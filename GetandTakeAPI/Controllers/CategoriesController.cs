using GetandTake.Business.Services.Abstract;
using GetandTake.Models;
using GetandTake.Models.DTOs.DetailDTO;
using GetandTake.Models.DTOs.ResponseDTO;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Xml.XPath;

namespace GetandTakeAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoriesController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

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

    [HttpGet("id/{id:int}")]
    public async Task<ActionResult<CategoryResponse>> GetCategoryByIdAsync(int id)
    {
        var category = await _categoryService.GetByIdAsync(id);

        if (category == null)
        {
            return BadRequest();
        }

        return category;
    }

    [HttpPost]
    public async Task<ActionResult<CategoryDetail>> CreateAsync(CategoryDetail category)
    {
        await _categoryService.CreateAsync(category);

        return category;
    }

    [HttpPut("id/{id:int}")]
    public async Task<ActionResult<CategoryDetail>> UpdateAsync(int id, CategoryDetail category)
    {
        await _categoryService.UpdateAsync(id, category);

        return category;
    }

    [HttpDelete("id/{id:int}")]
    public IActionResult Delete(int id)
    {
        _categoryService.Delete(id);

        return Ok("deleted process success");
    }

    [HttpGet("image/id/{id:int}")]
    public async Task<ActionResult<string>> GetImageByCategoryId(int id)
    {
        var imageUrl = await _categoryService.GetImageByCategoryIdAsync(id);

        return imageUrl;       
    }

    [HttpPatch("id/{id:int}")]
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