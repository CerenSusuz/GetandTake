using GetandTake.Core.DataAccess;
using GetandTake.DataAccess.Repositories.Abstract;
using GetandTake.Models;

namespace GetandTake.DataAccess.Repositories.Concrete;

public class SupplierRepository : BaseRepository<Supplier,NorthwindDbContext> , ISupplierRepository
{
	public SupplierRepository(NorthwindDbContext context) : base(context)
	{
	}
}