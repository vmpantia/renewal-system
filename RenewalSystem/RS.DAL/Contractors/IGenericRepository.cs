using System.Linq.Expressions;

namespace RS.DAL.Contractors
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> expression = null);
        TEntity GetOne(Expression<Func<TEntity, bool>> expression, params Expression<Func<TEntity, object>>[] includes);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}