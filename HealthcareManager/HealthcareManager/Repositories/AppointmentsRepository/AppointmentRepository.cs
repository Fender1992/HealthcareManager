using HealthcareManager.Data;
using HealthcareManager.Data.DTO;
using HealthcareManager.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace HealthcareManager.Repositories.AppointmentsRepository
{
    public class AppointmentRepository : IAppointmentRepository<AppointmentDTO>
    {
        private ApplicationDbContext _applicationDbContext;
        public AppointmentRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public async Task AddAsync(AppointmentDTO entity, string userId)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            entity.UserId = userId;

            await _applicationDbContext.Appointments.AddAsync(entity);
            await _applicationDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(AppointmentDTO entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            _applicationDbContext.Appointments.Remove(entity);
            await _applicationDbContext.SaveChangesAsync();
        }

        public async Task<List<AppointmentDTO>> GetAllAsync()
        {
            return await _applicationDbContext.Appointments.ToListAsync();
        }

        public async Task<AppointmentDTO> GetByIdAsync(int id)
        {
            if (_applicationDbContext.Appointments == null)
                return null;

            AppointmentDTO appointmentById = await _applicationDbContext.Appointments.FirstOrDefaultAsync(x => x.Id == id);
            return appointmentById;
        }


        public async Task UpdateAsync(AppointmentDTO entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            var existingEntity = await _applicationDbContext.Appointments.FindAsync(entity.Id);
            if (existingEntity == null)
            {
                throw new InvalidOperationException("Entity not found in the database.");
            }

            // Update the properties of the existing entity
            _applicationDbContext.Entry(existingEntity).CurrentValues.SetValues(entity);

            // Save changes to the database
            await _applicationDbContext.SaveChangesAsync();
        }
        public async Task<List<AppointmentDTO>> GetByUserIdAsync(string userId)
        {
            return await _applicationDbContext.Appointments
                                 .Where(a => a.UserId == userId)
                                 .ToListAsync();
        }


    }
}
