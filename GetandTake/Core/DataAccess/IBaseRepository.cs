using GetandTake.Core.Models;
using System.Linq.Expressions;

namespace GetandTake.Core.DataAccess;

public interface IBaseRepository<TEntity>
        where TEntity : BaseEntity
{
    Task<List<TEntity>> GetItemsAsync();

    Task<List<TEntity>> GetItemsAsync(
            Expression<Func<TEntity, bool>> expression,
            params Expression<Func<TEntity, object>>[] includes);

    Task<List<TEntity>> GetItemsAsync(
            params Expression<Func<TEntity, object>>[] includes);

    Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter,
        params Expression<Func<TEntity, object>>[] includes);

    Task<List<TEntity>> GetItemsAsync(int limit);

    Task CreateAsync(TEntity entity);

    void Update(TEntity entity);

    void Delete(Expression<Func<TEntity, bool>> expression);
}