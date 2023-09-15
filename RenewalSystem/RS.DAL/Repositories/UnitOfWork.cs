using RS.DAL.Contractors;
using RS.DAL.DataAccess;

namespace RS.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    { 
        private readonly RSDbContext _db;
        public UnitOfWork(RSDbContext db)
        {
            _db = db;
        }

        public IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            return new GenericRepository<TEntity>(_db);
        }

        public async Task SaveChangesAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
