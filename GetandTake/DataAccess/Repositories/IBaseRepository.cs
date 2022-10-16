using GetandTake.Models.Base;
using System.Linq.Expressions;

namespace GetandTake.DataAccess.Repositories;

public interface IBaseRepository<TEntity>
        where TEntity : class, new()
{
    IQueryable<TEntity> AsNoTracking { get; }

    Task<List<TEntity>> GetAllAsync();

    Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter);

    Task InsertAsync(TEntity entity);

    Task UpdateAsync(TEntity entity);

    Task DeleteAsync(TEntity entity);
}
