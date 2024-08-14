using HealthcareManager.Data.DTO;

namespace HealthcareManager.Repositories.AppointmentsRepository
{
    public interface IAppointmentRepository<T>
    {
        public Task AddAsync(T entity);
        public Task UpdateAsync(T entity);
        public Task DeleteAsync(T entity);
        public Task<List<AppointmentDTO>> GetAllAsync();
        public Task<AppointmentDTO> GetByIdAsync(int id);
    }
}


