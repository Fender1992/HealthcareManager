using HealthcareManager.Data;
using HealthcareManager.Data.DTO;
using Microsoft.EntityFrameworkCore;
using System;

namespace HealthcareManager.Repositories.ProviderRepository
{
    public class ProviderSQLRepositoryActions : IProviderRepository
    {
        private ApplicationDbContext _context;
        private ILogger<ProviderSQLRepositoryActions> _logger;
        public ProviderSQLRepositoryActions(ApplicationDbContext appDbContext)
        {
            _context = appDbContext;
        }
        public async Task<List<ProviderModelDto>> GetAllProviders()
        {
            return await _context.Providers
                .Select(p => new ProviderModelDto
                {
                    ProviderId = p.ProviderId,
                    ProviderName = p.ProviderName,
                    ProviderSpecialty = p.ProviderSpecialty,
                    CertificationDate = p.CertificationDate,
                    Role = p.Role,
                    YearsExperience = p.YearsExperience // Assuming this property exists
                })
                .ToListAsync();
        }

        public Task<ProviderModelDto> GetProviderById(int providerId)
        {
            throw new NotImplementedException();
        }

        public Task<ProviderModelDto> GetProviderByName(string name)
        {
            throw new NotImplementedException();
        }

    }
}
