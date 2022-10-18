using GetandTake.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace GetandTake.Configuration;

public static class DatabaseExtensions
{
    public static void RegisterDatabase(
        this WebApplicationBuilder builder,
        DatabaseSettings databaseSettings
        )
    {
        builder.Services.AddDbContext<NorthwindDbContext>(options =>
        {
            options.UseSqlServer(databaseSettings.DefaultConnection);
        }
        );
    }
}
