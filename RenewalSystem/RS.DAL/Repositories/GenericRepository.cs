using Microsoft.EntityFrameworkCore;
using RS.DAL.Contractors;
using RS.DAL.DataAccess;
using System.Linq.Expressions;

namespace RS.DAL.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly RSDbContext _db;
        private readonly DbSet<TEntity> _table;
        public GenericRepository(RSDbContext db)
        {
            _db = db;
            _table = _db.Set<TEntity>();
        }

        public IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> expression = null)
        {
            if (expression == null)
                return _table.AsNoTracking();

            return _table.Where(expression).AsNoTracking();
        }

        public TEntity GetOne(Expression<Func<TEntity, bool>> expression, params Expression<Func<TEntity, object>>[] includes)
        {
            var table = _table.AsNoTracking();
            foreach (var include in includes)
                table = table.Include(include);

            var result = table.FirstOrDefault(expression);
            if (result is null)
                throw new Exception("Data not found in the database.");

            return result;
        }

        public void Add(TEntity entity)
        {
            _table.Add(entity);
        }

        public void Update(TEntity entity)
        {
            _table.Update(entity);
        }

        public void Delete(TEntity entity)
        {
            _table.Remove(entity);
        }
    }
}
