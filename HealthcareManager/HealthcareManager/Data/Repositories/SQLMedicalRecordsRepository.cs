using HealthcareManager.Components.Account.Pages.DTO;
using Microsoft.EntityFrameworkCore;

namespace HealthcareManager.Data.Repositories
{
    public class SQLMedicalRecordsRepository
    {
        private ApplicationDbContext _context;
        private ILogger<SQLMedicalRecordsRepository> _logger;
        public SQLMedicalRecordsRepository(ApplicationDbContext context, ILogger<SQLMedicalRecordsRepository> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<List<UserFormDTO>> GetAllRecordsAsync()
        {
            try
            {
                var records = await _context.userForm
                    .Select(record => new UserFormDTO
                    {
                        UserId = record.UserId,
                        FirstName = record.FirstName,
                        LastName = record.LastName,
                        Address = record.Address,
                        PostalCode = record.PostalCode,
                        CreatedDate = record.CreatedDate,
                        BloodPressure = record.BloodPressure,
                        HeartRate = record.HeartRate,
                        Temperature = record.Temperature,
                        PulseOximetry = record.PulseOximetry,
                        Height = record.Height,
                        Weight = record.Weight,
                        Role = record.Role
                    }).ToListAsync();

                return records;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new List<UserFormDTO>();
            }
        }
    }
}
