using GetandTake.Business.Services.Abstract;
using GetandTake.Configuration.Settings;
using GetandTake.Models.DTOs.ResponseDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SmartBreadcrumbs.Attributes;

namespace GetandTake.Pages.Categories;

[Breadcrumb("Upload Image", FromPage = typeof(CategoryModel))]
public class UploadModel : PageModel
{
    private readonly ICategoryService _categoryService;
    private readonly AppSettings _appSettings;

    public string HostUrl { get; private set; }

    public UploadModel(
        ICategoryService categoryService,
        AppSettings appSettings)
    {
        _categoryService = categoryService;
        _appSettings = appSettings;
    }

    [BindProperty]
    public IFormFile Image { get; set; }

    [BindProperty]
    public CategoryResponse Category { get; set; }

    public async Task OnGetAsync(int id)
    {
        Category = await _categoryService.GetByIdAsync(id);
        HostUrl = _appSettings.Host.HostUrl;
    }

    public async Task<IActionResult> OnPost(int id)
    {
        await _categoryService.UploadImageAsync(Image, id);

        return RedirectToPage("Category");
    }
}