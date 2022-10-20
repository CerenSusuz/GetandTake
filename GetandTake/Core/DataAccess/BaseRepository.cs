using GetandTake.Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace GetandTake.Core.DataAccess;

public abstract class BaseRepository<TEntity, TContext> : IBaseRepository<TEntity>
    where TEntity : BaseEntity
    where TContext : DbContext
{
    protected readonly TContext _dbContext;

    private readonly DbSet<TEntity> _entities;

    public BaseRepository(TContext dbContext)
    {
        _dbContext = dbContext;
        _entities = _dbContext.Set<TEntity>();
    }

    public async Task<List<TEntity>> GetAllItemsAsync() =>
                await _entities.AsNoTracking().ToListAsync();

    public async Task<List<TEntity>> GetItemsByFilterWithIncludesAsync(
               Expression<Func<TEntity, bool>> expression,
               params Expression<Func<TEntity, object>>[] includes)
    {
        var query = _entities.Where(expression).AsNoTracking();

        if (includes.Any())
        {
            query = includes
                .Aggregate(query,
                    (
                        current, includeProperty) => current.Include(includeProperty)
                );
        }

        return await query.ToListAsync();
    }

    public async Task<List<TEntity>> GetItemsWithIncludesAsync(params Expression<Func<TEntity, object>>[] includes)
    {
        var query = _entities.AsNoTracking();
        if (includes.Any())
        {
            query = includes
                .Aggregate(query,
                    (
                        current, includeProperty) => current.Include(includeProperty)
                );
        }

        return await query.ToListAsync();
    }

    public async Task CreateAsync(TEntity entity)
    {
        await _entities.AddAsync(entity);
        _dbContext.SaveChanges();
    }

    public void Delete(Expression<Func<TEntity, bool>> expression)
    {
        _entities.RemoveRange(_entities.Where(expression));
        _dbContext.SaveChanges();
    }

    public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter, params Expression<Func<TEntity, object>>[] includes)
    {
        try
        {
            var query = _entities.Where(filter).AsNoTracking();
            if (includes.Any())
            {
                query = includes
                    .Aggregate(query,
                        (
                            current, includeProperty) => current.Include(includeProperty)
                    );
            }

            return await query.FirstAsync();
        }
        catch (Exception ex)
        {
            throw new Exception($"Unable to find item in database. Error: {ex.Message}");
        }
    }

    public void Update(TEntity entity)
    {
        _entities.Update(entity);
        _dbContext.SaveChanges();
    }

    public async Task<List<TEntity>> GetItemsByLimit(int limit) =>
        await _entities
            .Take(limit)
            .AsNoTracking()
            .ToListAsync();
}
