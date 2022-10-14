using GetandTake.Models.BaseModels;
using System.Linq.Expressions;
using System.Security.Principal;

namespace GetandTake.DataAccess.Repositories
{
    public interface IEntityRepository<TEntity>
            where TEntity : class, IBaseEntity, new()
    {
        IQueryable<TEntity> AsNoTracking { get; }
        Task<List<TEntity>> GetAllAsync();
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter);
        Task InsertAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
    }
}
