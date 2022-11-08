using GetandTake.Core.DataAccess;
using GetandTake.DataAccess.Repositories.Abstract;
using GetandTake.Models;

namespace GetandTake.DataAccess.Repositories.Concrete;

public class CategoryImageRepository : BaseRepository<CategoryImage, NorthwindDbContext>, ICategoryImageRepository
{
	public CategoryImageRepository(NorthwindDbContext context) : base(context)
	{
	}
}
