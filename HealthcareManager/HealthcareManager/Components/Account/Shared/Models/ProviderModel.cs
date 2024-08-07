namespace HealthcareManager.Components.Account.Shared.Models
{
    public class ProviderModel
    {
        public int ProviderId { get; set; }
        public string ProviderName { get; set; } = string.Empty;
        public string ProviderSpecialty { get; set; } = string.Empty;
        public DateOnly CertificationDate { get; set; }
        public int YearsExperience { get; set; }
        public string Role { get; set; } = string.Empty;

    }
}
