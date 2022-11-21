using GetandTake.Business.Services.Abstract;
using GetandTake.Configuration.Settings;
using GetandTake.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GetandTake.Pages.Categories;

public class ImagesModel : PageModel
{
    private readonly ICategoryService _categoryService;
    private readonly AppSettings _appSettings;

    public IEnumerable<Category> Categories { get; private set; }

    public string HostUrl { get; private set; }

    public ImagesModel(
        ICategoryService categoryService,
        AppSettings appSettings)
    {
        _categoryService = categoryService;
        _appSettings = appSettings;
    }


    public async Task OnGet()
    {
        Categories = await _categoryService.GetAllAsync();
        HostUrl = _appSettings.Host.HostUrl;
    }
}