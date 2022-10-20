using GetandTake.DataAccess.Repositories.Abstract;
using GetandTake.Models;
using GetandTake.Services.Abstract;

namespace GetandTake.Services.Concrete;

public class SupplierManager : ISupplierService
{
    private readonly ISupplierRepository _repository;

    public SupplierManager(ISupplierRepository repository) => _repository = repository;

    public async Task CreateAsync(Supplier supplier) => await _repository.CreateAsync(supplier);
 
    public void Delete(int supplierId) => _repository.Delete(entity => entity.SupplierID == supplierId);
 
    public async Task UpdateAsync(int supplierId, Supplier supplier)
    {
        var findSupplier = await _repository.GetAsync(category => category.SupplierID == supplierId);
        if (findSupplier != null)
        {
            supplier.SupplierID = supplierId;
            _repository.Update(supplier);
        }
    }

    public async Task<List<Supplier>> GetAllAsync() => await _repository.GetAllItemsAsync();

    public async Task<Supplier> GetByIdAsync(int supplierId) => await _repository.GetAsync(supplier => supplier.SupplierID == supplierId);
}
