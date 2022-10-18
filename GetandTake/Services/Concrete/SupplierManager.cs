using GetandTake.DataAccess.Repositories.Abstract;
using GetandTake.Models;
using GetandTake.Services.Abstract;

namespace GetandTake.Services.Concrete;

public class SupplierManager : ISupplierService
{
    private readonly ISupplierRepository _repository;

    public SupplierManager(ISupplierRepository repository)
    {
        _repository = repository;
    }

    public async Task CreateAsync(Supplier supplier)
    {
        await _repository.CreateAsync(supplier);
    }

    public void Delete(int supplierId)
    {
        _repository.Delete(entity => entity.SupplierID == supplierId);
    }

    public IEnumerable<Supplier> GetAll()
    {
        var suppliers = _repository.GetAll();

        return suppliers;
    }

    public Supplier GetById(int supplierId)
    {
        var findSupplier = _repository.AsNoTracking()
            .First(supplier => supplier.SupplierID == supplierId);

        return findSupplier;
    }

    public async Task UpdateAsync(int supplierId, Supplier supplier)
    {
        var findSupplier = await _repository.GetAsync(category => category.SupplierID == supplierId);
        if (findSupplier != null)
        {
            supplier.SupplierID = supplierId;
            _repository.Update(supplier);
        }
    }
}
