﻿using AutoMapper;
using GetandTake.Business.Services.Abstract;
using GetandTake.Configuration.Settings;
using GetandTake.Core.Aspects.Caching;
using GetandTake.Core.Utilities.Helper;
using GetandTake.DataAccess.Repositories.Abstract;
using GetandTake.Models;
using GetandTake.Models.DTOs.DetailDTO;
using GetandTake.Models.DTOs.ResponseDTO;
using Microsoft.AspNetCore.Mvc;

namespace GetandTake.Business.Services.Concrete;

public class CategoryManager : ICategoryService
{
    private readonly ICategoryRepository _repository;
    private readonly IMapper _mapper;
    private readonly AppSettings _appSettings;

    public CategoryManager(
        ICategoryRepository repository,
        IMapper mapper,
        AppSettings appSettings)
    {
        _repository = repository;
        _mapper = mapper;
        _appSettings = appSettings;
    }       

    [CacheRemoveAspect(nameof(ICategoryService.GetAllAsync))]
    public void Delete(int categoryId) =>
        _repository.Delete(entity => entity.CategoryID == categoryId);

    [CacheRemoveAspect(nameof(ICategoryService.GetAllAsync))]
    public async Task CreateAsync(CategoryDetail categoryDetail)
    {
        var category = _mapper.Map<Category>(categoryDetail);
        await _repository.CreateAsync(category);
    }
        
    [CacheRemoveAspect(nameof(ICategoryService.GetAllAsync))]
    public async Task UpdateAsync(int categoryId, CategoryDetail categoryDetail)
    {
        var findCategory = await _repository.GetAsync(category => category.CategoryID == categoryId);
        
        if (findCategory != null)
        {
            var category = _mapper.Map<Category>(categoryDetail);
            category.CategoryID = categoryId;
            _repository.Update(category);
        }
    }

    [CacheAspect]
    public async Task<List<CategoryResponse>> GetAllAsync()
    {
        var categories = await _repository.GetItemsAsync();

        return _mapper.Map<List<CategoryResponse>>(categories);
    }
        

    [CacheAspect]
    public async Task<CategoryResponse> GetByIdAsync(int categoryId)
    {
        var findCategory = await _repository.GetAsync(category => category.CategoryID == categoryId);

        return _mapper.Map<CategoryResponse>(findCategory);
    }
        

    [ResponseCache(NoStore = false, Duration = 10, Location = ResponseCacheLocation.Any)]
    public async Task UploadImageAsync(IFormFile file, int id)
    {
        var category = await GetByIdAsync(id);
        category.ImagePath = FileHelper.Upload(file);
        var categoryResult = _mapper.Map<Category>(category);
        _repository.Update(categoryResult);
    }

    public async Task<string> GetImageByCategoryIdAsync(int categoryId)
    {
        var findCategory = await _repository.GetAsync(category => category.CategoryID == categoryId);

        var imageUrl = $"{_appSettings.Host.HostUrl}{findCategory.ImagePath}";

        return imageUrl;
    }
}