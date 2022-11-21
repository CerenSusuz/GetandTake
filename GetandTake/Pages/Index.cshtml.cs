using GetandTake.Core.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GetandTake.Pages;

[LogActionFilter]
public class IndexModel : PageModel
{
    public void OnGet()
    {
    }
}