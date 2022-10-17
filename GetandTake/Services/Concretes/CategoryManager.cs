﻿using AutoMapper;
using GetandTake.Core.DataAccess;
using GetandTake.Models;
using GetandTake.Services.Abstracts;

namespace GetandTake.Services.Concretes;

public class CategoryManager : ICategoryService
{

    private readonly IBaseRepository<Category> _repository;

    private readonly IMapper _mapper;

    public CategoryManager(IBaseRepository<Category> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public void Delete(int categoryId)
    {
        _repository.Delete(entity => entity.CategoryID == categoryId);
    }

    public IEnumerable<Category> GetAll()
    {
        var categories =  _repository.GetAll();
        
        return categories;
    }

    public Category GetById(int categoryId)
    {
        var findCategory = _repository.AsNoTracking()
            .First(category => category.CategoryID == categoryId);

        return findCategory;
    }

    public async Task CreateAsync(Category category)
    {
        await _repository.CreateAsync(category);
    }

    public async Task UpdateAsync(int categoryId, Category category)
    {
        var findCategory = await _repository.GetAsync(category => category.CategoryID == categoryId);
        if (findCategory != null)
        {
            category.CategoryID = categoryId;
            _repository.Update(category);
        }
    }
}
