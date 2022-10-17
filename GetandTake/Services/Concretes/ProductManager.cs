using AutoMapper;
using GetandTake.DataAccess.Repositories.Abstract;
using GetandTake.Models;
using GetandTake.Models.DTOs.BaseDTO;
using GetandTake.Models.DTOs.ListDTO;
using GetandTake.Services.Abstracts;
using Microsoft.EntityFrameworkCore;

namespace GetandTake.Services.Concretes;

public class ProductManager : IProductService
{

    private readonly IProductRepository _repository;
    
    private readonly IMapper _mapper;

    public ProductManager(IProductRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public IEnumerable<ProductsDTO> GetAll()
    {
        var products = _repository.AsNoTracking()
            .Include(product => product.Category)
            .Include(product => product.Supplier);

        return _mapper.Map<List<ProductsDTO>>(products);
    }

    public IEnumerable<ProductsDTO> GetAllByCategoryId(int categoryId)
    {
        var products = _repository.AsNoTracking()
            .Where(category => category.CategoryID == categoryId)
            .Include(product => product.Category)
            .Include(product => product.Supplier);

        return _mapper.Map<List<ProductsDTO>>(products);
    }

    public IEnumerable<ProductsDTO> GetAllBySupplierId(int supplierId)
    {
        var products = _repository.AsNoTracking()
            .Where(supplier => supplier.SupplierID == supplierId)
            .Include(product => product.Supplier);

        return _mapper.Map<List<ProductsDTO>>(products);
    }

    public ProductsDTO GetById(int productId)
    {
        var findProduct = _repository.AsNoTracking()
            .Include(product => product.Category)
            .Include(product => product.Supplier)
            .First(product => product.ProductID == productId);

        return _mapper.Map<ProductsDTO>(findProduct);
    }

    public async Task CreateAsync(ProductDTO productDto)
    {
        var product = _mapper.Map<Product>(productDto);
        await _repository.CreateAsync(product);
    }

    public async Task UpdateAsync(int productId, ProductDTO productDto)
    {
        var findProduct = await _repository.GetAsync(product => product.ProductID == productId);
        if (findProduct != null)
        {
            var product = _mapper.Map<Product>(productDto);
            product.ProductID = productId;
            _repository.Update(product);
        }
    }
    
    public void Delete(int productId)
    {
        _repository.Delete(product => product.ProductID == productId);
    }
}
