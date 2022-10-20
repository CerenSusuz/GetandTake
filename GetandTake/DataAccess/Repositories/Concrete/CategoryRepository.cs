using GetandTake.Core.DataAccess;
using GetandTake.DataAccess.Repositories.Abstract;
using GetandTake.Models;

namespace GetandTake.DataAccess.Repositories.Concrete;

public class CategoryRepository : BaseRepository<Category,NorthwindDbContext>, ICategoryRepository
{
	public CategoryRepository(NorthwindDbContext context) : base(context)
	{
	}
}
