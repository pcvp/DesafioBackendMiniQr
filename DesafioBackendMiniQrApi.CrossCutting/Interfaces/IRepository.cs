using System.Linq.Expressions;
using DesafioBackendMiniQrApi.CrossCutting.Models;

namespace DesafioBackendMiniQrApi.CrossCutting.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {
        Task<TEntity?> GetByIdAsync(params object[] id);
        Task<IEnumerable<TEntity>> FindAsNoTrackingAsync(Expression<Func<TEntity, bool>> predicate);
        Task CreateAsync(TEntity obj);
        Task UpdateAsync(TEntity obj);
        Task DeleteAsync(Guid id);
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
