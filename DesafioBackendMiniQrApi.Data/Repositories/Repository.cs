using System.Linq.Expressions;
using DesafioBackendMiniQrApi.CrossCutting.Interfaces;
using DesafioBackendMiniQrApi.CrossCutting.Models;
using DesafioBackendMiniQrApi.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace DesafioBackendMiniQrApi.Data.Repositories
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        protected DataBaseContext _context;
        protected DbSet<TEntity> DbSet;

        protected Repository(DataBaseContext context)
        {
            _context = context;
            DbSet = _context.Set<TEntity>();
        }

        public async Task<TEntity?> GetByIdAsync(params object[] id)
        {
            return await DbSet.FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> FindAsNoTrackingAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public async Task CreateAsync(TEntity obj)
        {
            if (obj.Id.Equals(Guid.Empty))
            {
                obj.GenerateId();
            }

            await DbSet.AddAsync(obj);
        }

        public async Task UpdateAsync(TEntity obj)
        {
            await Task.Run(() =>
            {
                DbSet.Update(obj);
            });
        }

        public async Task DeleteAsync(Guid id)
        {
            DbSet.Remove(await DbSet.FindAsync(id) ?? throw new KeyNotFoundException(id.ToString()));
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }

        public void Dispose()
        {
            _context.Dispose();

            GC.SuppressFinalize(this);
        }
    }
}
