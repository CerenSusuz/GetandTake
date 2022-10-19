﻿using AutoMapper;
using GetandTake.DataAccess.Repositories.Abstract;
using GetandTake.Models;
using GetandTake.Models.DTOs.BaseDTO;
using GetandTake.Models.DTOs.ListDTO;
using GetandTake.Services.Abstract;
using Microsoft.EntityFrameworkCore;

namespace GetandTake.Services.Concrete;

public class ProductManager : IProductService
{
    private readonly IProductRepository _repository;

    private readonly IMapper _mapper;

    public ProductManager(IProductRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task CreateAsync(ProductDTO productDto)
    {
        var product = _mapper.Map<Product>(productDto);
        await _repository.CreateAsync(product);
    }

    public async Task UpdateAsync(int productId, ProductDTO productDto)
    {
        var findProduct = await _repository.GetItemsByFilterWithIncludesAsync(product => product.ProductID == productId);
        if (findProduct != null)
        {
            var product = _mapper.Map<Product>(productDto);
            product.ProductID = productId;
            _repository.Update(product);
        }
    }

    public void Delete(int productId) => _repository.Delete(product => product.ProductID == productId);

    public async Task<List<ProductsDTO>> GetAllAsync()
    {
        var products = await _repository.GetItemsWithIncludesAsync(include => include.Category, include => include.Supplier);

        return _mapper.Map<List<ProductsDTO>>(products);
    }

    public async Task<List<ProductsDTO>> GetAllByCategoryIdAsync(int categoryId)
    {
        var products = await _repository.GetItemsByFilterWithIncludesAsync(
            category => category.CategoryID == categoryId,
            include => include.Category, 
            include => include.Supplier);

        return _mapper.Map<List<ProductsDTO>>(products);
    }

    public async Task<List<ProductsDTO>> GetAllBySupplierIdAsync(int supplierId)
    {
        var products = await _repository.GetItemsByFilterWithIncludesAsync(supplier => supplier.SupplierID == supplierId,
            include => include.Supplier);

        return _mapper.Map<List<ProductsDTO>>(products);
    }

    public async Task<ProductsDTO> GetByIdAsync(int productId)
    {
        var findProduct = await _repository.GetAsync(product => product.ProductID == productId,
            include => include.Category, 
            include => include.Supplier);

        return _mapper.Map<ProductsDTO>(findProduct);
    }

    //TODO:Take() isn't used with Async method
    public async Task<List<ProductsDTO>> GetByMaximumAmountAsync(int maximumAmount)
    {
        if (maximumAmount == default)
        {
            return await GetAllAsync();
        }

        return await GetAllAsync().Take(maximumAmount);
    }
}

