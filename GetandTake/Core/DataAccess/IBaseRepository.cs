using GetandTake.Core.Models;
using System.Linq.Expressions;

namespace GetandTake.Core.DataAccess;

public interface IBaseRepository<TEntity>
        where TEntity : BaseEntity
{
    IQueryable<TEntity> AsNoTracking();

    List<TEntity> GetAll();

    Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter);

    Task CreateAsync(TEntity entity);

    void Update(TEntity entity);

    void Delete(Expression<Func<TEntity, bool>> expression);
}

