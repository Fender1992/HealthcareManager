using HealthcareManager.Data;
using HealthcareManager.Data.DTO;
using Microsoft.EntityFrameworkCore;

namespace HealthcareManager.Repositories
{
    public class MedicalRecordsRepository : IRepository<ApplicationUserDTO>
    {
        private readonly ApplicationDbContext _context;
        private ILogger<MedicationsDTO> _logger;
        public MedicalRecordsRepository(ApplicationDbContext context, ILogger<MedicationsDTO> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<ApplicationUserDTO> AddAsync(ApplicationUserDTO entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            await _context.UserForm.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<ApplicationUserDTO> DeleteAsync(ApplicationUserDTO entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            _context.UserForm.Remove(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<List<ApplicationUserDTO>> GetAllAsync()
        {
            try
            {
                return await _context.UserForm.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<ApplicationUserDTO> GetById(int id)
        {
            try
            {
                if (id != 0)
                {
                    return await _context.UserForm.FirstOrDefaultAsync(x => x.UserId == id.ToString());
                }
                else
                {
                    _logger.LogError("User may not exist");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex.Message}", ex);
            }
            return null;
        }

        public async Task<ApplicationUserDTO> UpdateAsync(ApplicationUserDTO entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            var item = await _context.UserForm.FirstOrDefaultAsync(x => x.UserId == entity.UserId);

            if (item is not null)
            {
                item.FirstName = entity.FirstName;
                item.LastName = entity.LastName;
                item.Address = entity.Address;
                item.BloodPressure = entity.BloodPressure ;

                await _context.SaveChangesAsync();
            }

            return entity;
        }
    }
}
