using GetandTake.Models;

namespace GetandTake.Services.Abstract;

public interface ISupplierService
{
    Task<List<Supplier>> GetAllAsync();

    Task<Supplier> GetByIdAsync(int supplierId);

    Task UpdateAsync(int supplierId, Supplier supplier);

    Task CreateAsync(Supplier supplier);

    void Delete(int supplierId);
}
