using System.ComponentModel.DataAnnotations;

namespace HealthcareManager.Data.Models
{
    public class ProviderModel
    {

        [Key]
        public int ProviderId { get; set; }
        public string ProviderName { get; set; } = string.Empty;
        public string ProviderSpecialty { get; set; } = string.Empty;
        public DateOnly CertificationDate { get; set; }
        public int YearsExperience { get; set; }
        public string Role { get; set; } = string.Empty;

    }
}
