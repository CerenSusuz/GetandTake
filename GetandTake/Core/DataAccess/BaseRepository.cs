using GetandTake.Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace GetandTake.Core.DataAccess;

public class BaseRepository<TEntity, TContext> : IBaseRepository<TEntity>
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

    public IQueryable<TEntity> AsNoTracking()
    {
        return _entities.AsNoTracking();
    }

    public async Task CreateAsync(TEntity entity)
    {
        await _entities.AddAsync(entity);
    }

    public void Delete(Expression<Func<TEntity, bool>> expression)
    {
        _entities.RemoveRange(_entities.Where(expression));
    }

    public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter)
    {
        try
        {
            var query = _entities.Where(filter).AsNoTracking();
            var item = await query.SingleOrDefaultAsync();
            return item;
        }
        catch (Exception ex)
        {
            throw new Exception($"Unable to find item in database. Error: {ex.Message}");
        }
    }
   
    public List<TEntity> GetAll()
    {
        return _dbContext.Set<TEntity>().ToList();
    }

    public void Update(TEntity entity)
    {
        _entities.Update(entity);
    }
}
