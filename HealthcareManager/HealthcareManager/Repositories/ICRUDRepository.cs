using HealthcareManager.Data.Models;

namespace HealthcareManager.Repositories
{
    public interface ICRUDRepository<T> where T : class
    {
        public Task<T> AddAsync(T entity);
        public Task<T> DeleteAsync(T entity);
        public Task<List<T>> GetAllAsync();
        public Task<T> UpdateAsync(T entity);
        public Task<T> GetById(int id);
    }
}
