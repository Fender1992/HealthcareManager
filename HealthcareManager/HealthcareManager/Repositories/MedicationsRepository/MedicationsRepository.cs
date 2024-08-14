using HealthcareManager.Data;
using HealthcareManager.Data.DTO;
using HealthcareManager.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace HealthcareManager.Repositories.MedicationsRepository
{
    public class MedicationsRepository : ICRUDRepository<MedicationsDTO>
    {
        private readonly ApplicationDbContext _context;
        private ILogger<MedicationsDTO> _logger;
        public MedicationsRepository(ApplicationDbContext context, ILogger<MedicationsDTO> logger)
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
                var medications = await _context.Medications
                .Select(record => new MedicationsDTO
                {
                    MedicationName = record.MedicationName,
                    MedicationCount = record.MedicationCount,
                    MedicationDescription = record.MedicationDescription,
                    MedicationId = record.MedicationId,
                    MedicationType = record.MedicationType,
                    DatePrescribed = record.DatePrescribed,
                }).ToListAsync();

                return medications;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

            
        }

        public async Task<MedicationsDTO> GetById(int id)
        {
            return await _context.Medications.FirstOrDefaultAsync(x => x.MedicationId == id);
        }

        public Task<MedicationsDTO> UpdateAsync(MedicationsDTO entity)
        {
            throw new NotImplementedException();
        }
    }
    
}

