using GetandTake.Core.DataAccess;
using GetandTake.DataAccess.Repositories.Abstract;
using GetandTake.Models;

namespace GetandTake.DataAccess.Repositories.Concrete;

public class ProductRepository : BaseRepository<Product, NorthwindDbContext>, IProductRepository
{
	public ProductRepository(NorthwindDbContext context) : base(context)
	{
	}
}
