using GetandTake.Business.Services.Abstract;
using GetandTake.Models;
using Microsoft.AspNetCore.Mvc;

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

    [HttpGet]
    public async Task<ActionResult<List<Category>>> GetAllCategoriesAsync()
    {
        var categories = await _categoryService.GetAllAsync();
        
        if (categories == null)
        {
            return BadRequest();
        }

        return Ok(categories);
    }
}