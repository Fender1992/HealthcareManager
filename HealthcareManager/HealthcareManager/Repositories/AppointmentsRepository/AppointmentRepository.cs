using HealthcareManager.Data;
using HealthcareManager.Data.DTO;
using HealthcareManager.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace HealthcareManager.Repositories.AppointmentsRepository
{
    public class AppointmentRepository : IAppointmentRepository<AppointmentDTO>
    {
        private ApplicationDbContext ApplicationDbContext;
        public AppointmentRepository(ApplicationDbContext applicationDbContext)
        {
            ApplicationDbContext = applicationDbContext;
        }
        public async Task AddAsync(AppointmentDTO entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            await ApplicationDbContext.Appointments.AddAsync(entity);
            await ApplicationDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(AppointmentDTO entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            ApplicationDbContext.Appointments.Remove(entity);
            await ApplicationDbContext.SaveChangesAsync();
        }

        public async Task<List<AppointmentDTO>> GetAllAsync()
        {
            return await ApplicationDbContext.Appointments.ToListAsync();
        }

        public async Task<AppointmentDTO> GetByIdAsync(int id)
        {
            if (ApplicationDbContext.Appointments == null)
                return null;

            AppointmentDTO appointmentById = await ApplicationDbContext.Appointments.FirstOrDefaultAsync(x => x.Id == id);
            return appointmentById;
        }


        public async Task UpdateAsync(AppointmentDTO entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            var existingEntity = await ApplicationDbContext.Appointments.FindAsync(entity.Id);
            if (existingEntity == null)
            {
                throw new InvalidOperationException("Entity not found in the database.");
            }

            // Update the properties of the existing entity
            ApplicationDbContext.Entry(existingEntity).CurrentValues.SetValues(entity);

            // Save changes to the database
            await ApplicationDbContext.SaveChangesAsync();
        }

        
    }
}
