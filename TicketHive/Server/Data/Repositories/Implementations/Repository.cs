using System.Linq.Expressions;
using TicketHive.Server.Data.Databases;
using TicketHive.Server.Data.Repositories.Interfaces;

namespace TicketHive.Server.Data.Repositories.Implementations
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly AppDbContext _Context;

        public Repository(AppDbContext context)
        {
            _Context = context;
        }
        public TEntity GetById(int id)
        {
            return _Context.Set<TEntity>().Find(id);
        }
        public IEnumerable<TEntity> GetAll()
        {
            return _Context.Set<TEntity>().ToList();
        }
        public IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> predicate)
        {
            return _Context.Set<TEntity>().Where(predicate);
        }
        public void Add(TEntity entity)
        {
            _Context.Set<TEntity>().Add(entity);
        }
        public void AddRange(IEnumerable<TEntity> entities)
        {
            _Context.Set<TEntity>().AddRange(entities);
        }
        public void Remove(TEntity entity)
        {
            _Context.Set<TEntity>().Remove(entity);
        }
        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _Context.Set<TEntity>().RemoveRange(entities);
        }

    }
}
