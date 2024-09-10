using HealthcareManager.Data;
using HealthcareManager.Data.DTO;
using HealthcareManager.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace HealthcareManager.Repositories.AppointmentsRepository
{
    public class AppointmentRepository : IAppointmentRepository<AppointmentDTO>
    {
        private ApplicationDbContext ApptRepo;
        private List<AppointmentDTO> appointmentsList = new List<AppointmentDTO>();
        public AppointmentRepository(ApplicationDbContext applicationDbContext)
        {
            ApptRepo = applicationDbContext;
        }
        public async Task AddAsync(AppointmentDTO entity, string userId)
        {
            try
            {
                entity = new AppointmentDTO
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    Description = entity.Description,
                    UserId = entity.UserId,
                    Date = new DateOnly(),
                    Time = new TimeOnly()
                };

                if (entity == null)
                    throw new ArgumentNullException(nameof(entity));
                else
                {
                    await ApptRepo.Appointments.AddAsync(entity);
                    await ApptRepo.SaveChangesAsync();
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        public async Task DeleteAsync(AppointmentDTO entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            ApptRepo.Appointments.Remove(entity);
            await ApptRepo.SaveChangesAsync();
        }

        public async Task<List<AppointmentDTO>> GetAllAsync()
        {
            
            var result =  await ApptRepo.Appointments.ToListAsync();
            return result;
        }

        public async Task<AppointmentDTO> GetByIdAsync(int id)
        {
            if (ApptRepo.Appointments == null)
                return null;

            AppointmentDTO appointmentById = await ApptRepo.Appointments.FirstOrDefaultAsync(x => x.Id == id);
            return appointmentById;
        }


        public async Task UpdateAsync(AppointmentDTO entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            var existingEntity = await ApptRepo.Appointments.FindAsync(entity.Id);
            if (existingEntity == null)
            {
                throw new InvalidOperationException("Entity not found in the database.");
            }

            // Update the properties of the existing entity
            ApptRepo.Entry(existingEntity).CurrentValues.SetValues(entity);

            // Save changes to the database
            await ApptRepo.SaveChangesAsync();
        }
        public async Task<List<AppointmentDTO>> GetByUserIdAsync(string userId)
        {
            return await ApptRepo.Appointments
                                 .Where(a => a.UserId == userId)
                                 .ToListAsync();
        }


    }
}
