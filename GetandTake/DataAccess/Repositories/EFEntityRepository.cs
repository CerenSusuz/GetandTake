using GetandTake.DataAccessLayer.EF;
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

        public void Add(TEntity entity)
        {
            var addedEntity = _context.Entry(entity);
            addedEntity.State = EntityState.Added;
            _context.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            var deletedEntity = _context.Entry(entity);
            deletedEntity.State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            var entity = _entities.FirstOrDefault(filter);
            if (entity != null)
                _context.Entry(entity).State = EntityState.Detached;
            return entity;
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>>? filter = null)
        {
            return filter == null
                                 ? _entities.ToList()
                                 : _entities.Where(filter).ToList();
        }

        public void Update(TEntity entity)
        {
            var oldEntity = Get(entity => entity.Id == entity.Id);
            if (oldEntity == null)
                throw new(entity.Id + " id, is not found for " + typeof(TEntity).Name);
            entity.CreatedAt = oldEntity.CreatedAt;
            entity.UpdatedAt = DateTime.Now;
            _context.Update(entity);
            _context.SaveChanges();
        }
    }
}
