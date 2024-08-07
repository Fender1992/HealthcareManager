using HealthcareManager.Data.DTO;

namespace HealthcareManager.Repositories.ProviderRepository
{
    public interface IProviderRepository
    {
        Task<List<ProviderModelDto>> GetAllProviders();
        Task<ProviderModelDto> GetProviderById(int providerId);
        Task<ProviderModelDto> GetProviderByName(string name);
    }
}
