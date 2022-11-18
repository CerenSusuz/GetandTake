﻿using AutoMapper;
using GetandTake.Business.Services.Abstract;
using GetandTake.Core.Aspects.Caching;
using GetandTake.DataAccess.Repositories.Abstract;
using GetandTake.Models;
using GetandTake.Models.DTOs.BaseDTO;
using GetandTake.Models.DTOs.ListDTO;

namespace GetandTake.Business.Services.Concrete;

public class ProductManager : IProductService
{
    private readonly IProductRepository _repository;
    private readonly IMapper _mapper;
    public ProductManager(IProductRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    [CacheRemoveAspect(nameof(IProductService.GetAllAsync))]
    public async Task CreateAsync(ProductDTO productDto)
    {
        var product = _mapper.Map<Product>(productDto);
        await _repository.CreateAsync(product);
    }

    [CacheRemoveAspect(nameof(IProductService.GetAllAsync))]
    public async Task UpdateAsync(int productId, ProductDTO productDto)
    {
        var findProduct = await _repository.GetAsync(
            product => product.ProductID == productId);
        if (findProduct != null)
        {
            var product = _mapper.Map<Product>(productDto);
            product.ProductID = productId;
            _repository.Update(product);
        }
    }

    [CacheRemoveAspect(nameof(IProductService.GetAllAsync))]
    public void Delete(int productId) =>
        _repository.Delete(product => product.ProductID == productId);

    [CacheAspect]
    public async Task<List<ProductsDTO>> GetAllAsync()
    {
        var products = await _repository.GetItemsAsync(include => include.Category, include => include.Supplier);

        return _mapper.Map<List<ProductsDTO>>(products);
    }

    [CacheAspect]
    public async Task<List<ProductsDTO>> GetAllByCategoryIdAsync(int categoryId)
    {
        var products = await _repository.GetItemsAsync(
            category => category.CategoryID == categoryId,
            include => include.Category,
            include => include.Supplier);

        return _mapper.Map<List<ProductsDTO>>(products);
    }

    [CacheAspect]
    public async Task<List<ProductsDTO>> GetAllBySupplierIdAsync(int supplierId)
    {
        var products = await _repository.GetItemsAsync(supplier => supplier.SupplierID == supplierId,
            include => include.Supplier);

        return _mapper.Map<List<ProductsDTO>>(products);
    }

    [CacheAspect]
    public async Task<ProductsDTO> GetByIdAsync(int productId)
    {
        var findProduct = await _repository.GetAsync(product => product.ProductID == productId,
            include => include.Category,
            include => include.Supplier);

        return _mapper.Map<ProductsDTO>(findProduct);
    }

    [CacheAspect]
    public async Task<List<ProductsDTO>> GetByMaxAmountOfAsync(int maximumAmount)
    {
        if (maximumAmount == default)
        {
            return await GetAllAsync();
        }
        var entities = await _repository.GetItemsAsync(maximumAmount);

        return _mapper.Map<List<ProductsDTO>>(entities);
    }
}
