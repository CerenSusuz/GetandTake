using GetandTake.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace GetandTake.Configuration.Services;

public static class DatabaseExtension
{
    public static void RegisterDatabase(WebApplicationBuilder? builder)
    {
        builder.Services.AddDbContext<NorthwindDbContext>(options =>
            {
                options.UseSqlServer("Server=EPTRANKW0038\\SQLEXPRESS;Database=Northwind;Trusted_Connection=True;");
            }
        );
    }
}
