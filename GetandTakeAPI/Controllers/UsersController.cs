using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GetandTakeAPI.Controllers;

/// <summary>
/// Users controller.
/// </summary>
[Route("api/[controller]")]
[ApiController]
[Authorize(Roles = "Admin")]
public class UsersController : Controller
{
    private readonly UserManager<IdentityUser> _userManager;

    /// <summary>
    /// Initializes a new instance of the <see cref="UsersController"/> class.
    /// </summary>
    /// <param name="userManager">to coneection with user application logic</param>
    public UsersController(UserManager<IdentityUser> userManager)
    {
        _userManager = userManager;
    }

    /// <summary>
    /// Gets all users.
    /// </summary>
    ///     /// <remarks>
    /// Sample response:
    ///
    ///     GET / users
    ///     {
    ///       "id": "2adbf92a-5fcf-4675-a8b8-bf460e27864a",
    ///       "userName": "test@hotmail.com",
    ///       "normalizedUserName": "TEST@HOTMAIL.COM",
    ///       "email": "test@hotmail.com", 
    ///       "normalizedEmail": "test@HOTMAIL.COM",
    ///       "emailConfirmed": true, 
    ///       "passwordHash": "AQAAAAEAACcQAAAAEM23i8M5EdPqR759OJpmvqcQTCMGFSDH9SgReqN/n1yEGNPU/99PFFV4O8CRIQXEiQ==", 
    ///       "securityStamp": "XZOEA243DGTUQH7VV6VT6GEJTN3UBBYF",
    ///       "concurrencyStamp": "59146690-6ead-42e2-a3d2-2ccb3ceb1053",
    ///       "phoneNumber": "5554443311",
    ///       "phoneNumberConfirmed": false,
    ///       "twoFactorEnabled": false,
    ///       "lockoutEnd": null,
    ///       "lockoutEnabled": true,
    ///       "accessFailedCount": 0
    ///     }
    ///
    /// </remarks>
    /// <returns>
    /// A <see cref="Task"/> representing the asynchronous operation with list of <see cref="IdentityUser"/>
    /// </returns>
    /// <response code="200"> User List has been found.</response>
    /// <response code="404"> Unable to find users.</response>
    [HttpGet(Name = nameof(GetAllUsers))]
    [ProducesResponseType(typeof(IdentityUser), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
    public ActionResult<List<IdentityUser>> GetAllUsers()
    {
        var users = _userManager.Users.ToList();

        if (users == null)
        {
            return NotFound();
        }

        return users;
    }
}