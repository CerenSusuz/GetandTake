using GetandTake.DataAccessLayer.EF;
using Microsoft.EntityFrameworkCore;

namespace GetandTake.Configuration;

public class ServicesConfiguration
{
    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<NorthwindDbContext>(options => 
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
    }

}
