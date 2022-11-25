using AutoMapper;
using GetandTake.Business.Services.Abstract;
using GetandTake.Models;
using GetandTake.Models.DTOs.DetailDTO;
using GetandTake.Models.DTOs.ResponseDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SmartBreadcrumbs.Attributes;

namespace GetandTake.Pages.Categories;

[Breadcrumb("Edit Category", FromPage = typeof(CategoryModel))]
public class EditModel : PageModel
{
    private readonly ICategoryService _categoryService;
    private readonly IMapper _mapper;

    [BindProperty]
    public CategoryResponse Category { get; set; }

    public EditModel(
        ICategoryService categoryService,
        IMapper mapper)
    {
        _categoryService = categoryService;
        _mapper = mapper;
    } 

    public async Task OnGet(int id)
    {
        Category = await _categoryService.GetByIdAsync(id);
    }

    public async Task<IActionResult> OnPost(int id)
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        var category = _mapper.Map<CategoryDetail>(Category);
        await _categoryService.UpdateAsync(id, category);

        return RedirectToPage("Category");
    }
}

