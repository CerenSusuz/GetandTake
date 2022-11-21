using GetandTake.Configuration.Settings;
using GetandTake.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace GetandTake.Configuration.Extensions;

public static class DatabaseExtensions
{
    public static void RegisterDatabase(
        this IServiceCollection services,
        AppSettings appSettings)
    {
        services.AddDbContext<NorthwindDbContext>(options =>
        {
            options.UseSqlServer(appSettings.Database.DefaultConnection);
        });
    }
}
