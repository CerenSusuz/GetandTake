using GetandTake.Models.BaseModels;
using System.Linq.Expressions;
using System.Security.Principal;

namespace GetandTake.DataAccess.Repositories
{
    public interface IEntityRepository<TEntity>
            where TEntity : class, IBaseEntity, new()
    {
        IQueryable<TEntity> Table { get; }
        /// <summary>
        /// To Table as No Tracking
        /// </summary>
        IQueryable<TEntity> AsNoTracking { get; }
        List<TEntity> GetAll(Expression<Func<TEntity, bool>>? filter = null);
        TEntity Get(Expression<Func<TEntity, bool>> filter);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
