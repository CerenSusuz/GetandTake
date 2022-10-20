using GetandTake.Core.Models;
using System.Linq.Expressions;

namespace GetandTake.Core.DataAccess;

public interface IBaseRepository<TEntity>
        where TEntity : BaseEntity
{
    Task<List<TEntity>> GetAllItemsAsync();

    Task<List<TEntity>> GetItemsByFilterWithIncludesAsync(
            Expression<Func<TEntity, bool>> expression,
            params Expression<Func<TEntity, object>>[] includes);

    Task<List<TEntity>> GetItemsWithIncludesAsync(
            params Expression<Func<TEntity, object>>[] includes);

    Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter,
        params Expression<Func<TEntity, object>>[] includes);

    Task<List<TEntity>> GetItemsByLimit(int limit);

    Task CreateAsync(TEntity entity);

    void Update(TEntity entity);

    void Delete(Expression<Func<TEntity, bool>> expression);
}

