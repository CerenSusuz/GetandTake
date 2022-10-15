using AutoMapper;
using GetandTake.DataAccess.Repositories;
using GetandTake.Models;
using GetandTake.Models.DTOs.ListDTO;
using GetandTake.Services.Abstracts;
using Microsoft.EntityFrameworkCore;

namespace GetandTake.Services.Concretes
{
    public class CategoryManager : ICategoryService
    {
        private readonly IEntityRepository<Category> _repository;
        private readonly IMapper _mapper;
        public CategoryManager(IEntityRepository<Category> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task DeleteAsync(int id)
        {
            var findCategory = await _repository.GetAsync(entity => entity.CategoryID == id);
            await _repository.DeleteAsync(findCategory);
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            var categories = await _repository.GetAllAsync();
            return _mapper.Map<List<Category>>(categories);
        }

        public Task<Category> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task InsertAsync(Category dto)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(int id, Category category)
        {
            throw new NotImplementedException();
        }
    }
}
