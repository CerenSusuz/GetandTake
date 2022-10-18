using GetandTake.Models;

namespace GetandTake.Services.Abstract;

public interface ISupplierService
{
    IEnumerable<Supplier> GetAll();

    Supplier GetById(int supplierId);

    Task UpdateAsync(int supplierId, Supplier supplier);

    Task CreateAsync(Supplier supplier);

    void Delete(int supplierId);
}
