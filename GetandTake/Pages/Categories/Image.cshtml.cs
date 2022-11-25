using GetandTake.Business.Services.Abstract;
using GetandTake.Configuration.Settings;
using GetandTake.Models;
using GetandTake.Models.DTOs.ResponseDTO;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GetandTake.Pages.Categories
{
    public class ImageModel : PageModel
    {
        private readonly ICategoryService _categoryService;
        private readonly AppSettings _appSettings;

        public CategoryResponse Category { get; private set; }

        public string HostUrl { get; private set; }

        public ImageModel(
            ICategoryService categoryService,
            AppSettings appSettings)
        {
            _categoryService = categoryService;
            _appSettings = appSettings;
        }
        
        public async Task OnGet(int id)
        {
            Category = await _categoryService.GetByIdAsync(id);
            HostUrl = _appSettings.Host.HostUrl;
        }
    }
}