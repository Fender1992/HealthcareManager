using HealthcareManager.Data;
using HealthcareManager.Data.DTO;
using HealthcareManager.Data.Models;
using HealthcareManager.Utility;
using Microsoft.EntityFrameworkCore;

namespace HealthcareManager.Repositories.MedicationsRepository
{
    public class MedicationRepository : IRepository<MedicationsDTO>
    {
        private readonly ApplicationDbContext _context;
        private ILogger<MedicationsDTO> _logger;
        public MedicationRepository(ApplicationDbContext context, ILogger<MedicationsDTO> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<MedicationsDTO> AddAsync(MedicationsDTO entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            await _context.Medications.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<MedicationsDTO> DeleteAsync(MedicationsDTO entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            _context.Medications.Remove(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<List<MedicationsDTO>> GetAllAsync()
        {
            try
            {
                return await _context.Medications.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<MedicationsDTO> GetById(int id)
        {
            try
            {
                if (id != 0)
                {
                    return await _context.Medications.FirstOrDefaultAsync(x => x.MedicationId == id);
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

        public async Task<MedicationsDTO> UpdateAsync(MedicationsDTO entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            var item = await _context.Medications.FirstOrDefaultAsync(x => x.MedicationId == entity.MedicationId);

            if (item is not null)
            {
                item.MedicationName = entity.MedicationName;
                item.MedicationDescription = entity.MedicationDescription;
                item.DatePrescribed = entity.DatePrescribed;
                item.MedicationType = entity.MedicationType;

                await _context.SaveChangesAsync();
            }

            return entity;
        }
    }

}

