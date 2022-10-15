using AutoMapper;
using GetandTake.DataAccess.Repositories;
using GetandTake.Models;
using GetandTake.Models.DTOs.BaseDTO;
using GetandTake.Models.DTOs.ListDTO;
using GetandTake.Services.Abstracts;
using Microsoft.EntityFrameworkCore;

namespace GetandTake.Services.Concretes
{
    public class ProductManager : IProductService
    {
        private readonly IEntityRepository<Product> _repository;
        private readonly IMapper _mapper;
        public ProductManager(IEntityRepository<Product> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductsDTO>> GetAllAsync()
        {
            var products = _repository.AsNoTracking
                .Include(p => p.Category)
                .Include(p => p.Supplier);
            return _mapper.Map<List<ProductsDTO>>(products);
        }

        public async Task<IEnumerable<ProductsDTO>> GetAllByCategoryAsync(int categoryId)
        {
            var products = _repository.AsNoTracking
                .Where(c => c.CategoryID == categoryId)
                .Include(p => p.Category)
                .Include(s=>s.Supplier);
            return _mapper.Map<List<ProductsDTO>>(products);
        }

        public async Task<IEnumerable<ProductsDTO>> GetAllBySupplierAsync(int supplierId)
        {
            var products = _repository.AsNoTracking
                .Where(c => c.SupplierID == supplierId)
                .Include(p => p.Supplier);
            return _mapper.Map<List<ProductsDTO>>(products);
        }

        public async Task<ProductsDTO> GetAsync(int id)
        {
            var findProduct = _repository.AsNoTracking
                .Include(p => p.Category)
                .Where(p => p.ProductID == id)
                .FirstOrDefault();
            return _mapper.Map<ProductsDTO>(findProduct);
        }

        public async Task InsertAsync(ProductDTO dto)
        {
            var product = _mapper.Map<Product>(dto);
            await _repository.InsertAsync(product);
        }

        public async Task UpdateAsync(int id, ProductDTO dto)
        {
            var findProduct = await _repository.GetAsync(entity => entity.ProductID == id);
            if (findProduct != null)
            {
                var product = _mapper.Map<Product>(dto);
                product.ProductID = id;
                await _repository.UpdateAsync(product);
            }
        }
        public async Task DeleteAsync(int id)
        {
            var findProduct = await _repository.GetAsync(entity => entity.ProductID == id);
            await _repository.DeleteAsync(findProduct);
        }
    }
}
