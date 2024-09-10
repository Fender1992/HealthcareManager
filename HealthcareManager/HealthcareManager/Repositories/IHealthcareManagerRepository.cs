using HealthcareManager.Data.DTO;
using HealthcareManager.Domain.Entities;
using System.Linq.Expressions;

namespace HealthcareManager.Repositories
{
    public interface IHealthcareManagerRepository<TEntity, D> : IDisposable where TEntity : BaseEntity where D : IBaseDTO<TEntity>
    {
        Task<D> AddOrUpdateAsync(D dto, TEntity entity);
        Task<bool> DeleteAsync(TEntity entity);
        IAsyncEnumerable<D> GetAllAsync(bool tracking = false, bool selectSlim = false);
        IAsyncEnumerable<D> FindAsync(Expression<Func<TEntity, bool>> predicate, bool t = false, bool selectSlim = false);
        Task<D> GetByIdAsync(object id, bool t = false);
    }
}
