using GetandTake.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace GetandTake.Configuration;

public static class DatabaseExtensions
{
    public static void RegisterDatabase(
        this WebApplicationBuilder builder,
        AppSettings appSettings)
    {
        builder.Services.AddDbContext<NorthwindDbContext>(options =>
        {
            options.UseSqlServer(appSettings.Database.DefaultConnection);
        });
    }
}
