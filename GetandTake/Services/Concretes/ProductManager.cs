using AutoMapper;
using GetandTake.DataAccess.Repositories;
using GetandTake.Models;
using GetandTake.Models.DTOs.BaseDTO;
using GetandTake.Models.DTOs.ListDTO;
using GetandTake.Services.Abstracts;
using Microsoft.EntityFrameworkCore;

namespace GetandTake.Services.Concretes;

public class ProductManager : IProductService
{

    private readonly IBaseRepository<Product> _repository;
    
    private readonly IMapper _mapper;

    public ProductManager(IBaseRepository<Product> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ProductsDTO>> GetAllAsync()
    {
        var products = _repository.AsNoTracking
            .Include(product => product.Category)
            .Include(product => product.Supplier);

        return _mapper.Map<List<ProductsDTO>>(products);
    }

    public async Task<IEnumerable<ProductsDTO>> GetAllByCategoryIdAsync(int categoryId)
    {
        var products = _repository.AsNoTracking
            .Where(category => category.CategoryID == categoryId)
            .Include(product => product.Category)
            .Include(product => product.Supplier);

        return _mapper.Map<List<ProductsDTO>>(products);
    }

    public async Task<IEnumerable<ProductsDTO>> GetAllBySupplierIdAsync(int supplierId)
    {
        var products = _repository.AsNoTracking
            .Where(supplier => supplier.SupplierID == supplierId)
            .Include(product => product.Supplier);

        return _mapper.Map<List<ProductsDTO>>(products);
    }

    public async Task<ProductsDTO> GetByIdAsync(int productId)
    {
        var findProduct = _repository.AsNoTracking
            .Include(product => product.Category)
            .FirstOrDefault(product => product.ProductID == productId);

        return _mapper.Map<ProductsDTO>(findProduct);
    }

    public async Task InsertAsync(ProductDTO productDto)
    {
        var product = _mapper.Map<Product>(productDto);
        await _repository.InsertAsync(product);
    }

    public async Task UpdateAsync(int productId, ProductDTO productDto)
    {
        var findProduct = await _repository.GetAsync(product => product.ProductID == productId);
        if (findProduct != null)
        {
            var product = _mapper.Map<Product>(productDto);
            product.ProductID = productId;
            await _repository.UpdateAsync(product);
        }
    }
    
    public async Task DeleteAsync(int productId)
    {
        var findProduct = await _repository.GetAsync(product => product.ProductID == productId);
        await _repository.DeleteAsync(findProduct);
    }
}
