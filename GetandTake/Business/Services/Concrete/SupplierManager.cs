using GetandTake.Business.Services.Abstract;
using GetandTake.Core.Aspects.Caching;
using GetandTake.DataAccess.Repositories.Abstract;
using GetandTake.Models;

namespace GetandTake.Business.Services.Concrete;

public class SupplierManager : ISupplierService
{
    private readonly ISupplierRepository _repository;

    public SupplierManager(ISupplierRepository repository) =>
        _repository = repository;

    [CacheRemoveAspect(nameof(ISupplierService.GetAllAsync))]
    public async Task CreateAsync(Supplier supplier) =>
        await _repository.CreateAsync(supplier);

    [CacheRemoveAspect(nameof(ISupplierService.GetAllAsync))]
    public void Delete(int supplierId) =>
        _repository.Delete(entity => entity.SupplierID == supplierId);

    [CacheRemoveAspect(nameof(ISupplierService.GetAllAsync))]
    public async Task UpdateAsync(int supplierId, Supplier supplier)
    {
        var findSupplier = await _repository.GetAsync(category => category.SupplierID == supplierId);
        if (findSupplier != null)
        {
            supplier.SupplierID = supplierId;
            _repository.Update(supplier);
        }
    }

    [CacheAspect]
    public async Task<List<Supplier>> GetAllAsync() =>
        await _repository.GetItemsAsync();

    [CacheAspect]
    public async Task<Supplier> GetByIdAsync(int supplierId) =>
        await _repository.GetAsync(supplier => supplier.SupplierID == supplierId);
}
