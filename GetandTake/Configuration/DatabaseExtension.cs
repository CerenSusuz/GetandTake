using GetandTake.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace GetandTake.Configuration;

public static class DatabaseExtension
{
    public static void RegisterDatabase(WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<NorthwindDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            }
        );
    }
}
