﻿using GetandTake.DataAccessLayer.EF;
using GetandTake.Models.BaseModels;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace GetandTake.DataAccess.Repositories
{
    public class EFEntityRepository<TEntity> : IEntityRepository<TEntity>
        where TEntity : class, IBaseEntity, new()
    {
        private readonly NorthwindDbContext _context;
        private readonly DbSet<TEntity> _entities;
        public EFEntityRepository(NorthwindDbContext context)
        {
            _context = context;
            _entities = _context.Set<TEntity>();
        }
        public IQueryable<TEntity> Table => _entities;

        public IQueryable<TEntity> AsNoTracking => _entities.AsNoTracking();

        public async Task InsertAsync(TEntity entity)
        {
            var addedEntity = _context.Entry(entity);
            addedEntity.State = EntityState.Added;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(TEntity entity)
        {
            var deletedEntity = _context.Entry(entity);
            deletedEntity.State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter)
        {
            var entity = await _entities.FindAsync(filter);
            if (entity != null)
                _context.Entry(entity).State = EntityState.Detached;
            return entity;
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
           return await _entities.ToListAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
