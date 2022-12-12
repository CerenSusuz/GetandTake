﻿using Microsoft.AspNetCore.Identity;

namespace GetandTake.Core.Models.Account;

public class ApplicationUser : IdentityUser
{
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public int UsernameChangeLimit { get; set; } = 10;

    public byte[] ProfilePicture { get; set; }
}