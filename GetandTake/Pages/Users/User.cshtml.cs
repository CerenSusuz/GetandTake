using GetandTake.Core.Models.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SmartBreadcrumbs.Attributes;

namespace GetandTake.Pages.Users;

[Authorize(Roles = Role.User)]
[Breadcrumb("Users", FromPage = typeof(IndexModel))]
public class UserModel : PageModel
{
    private UserManager<IdentityUser> _userManager;

    public IEnumerable<IdentityUser> Users { get; private set; }

    public UserModel(UserManager<IdentityUser> userManager)=> _userManager = userManager;


    public async Task OnGet()
    {
        Users = _userManager.Users.ToList();
    }
}