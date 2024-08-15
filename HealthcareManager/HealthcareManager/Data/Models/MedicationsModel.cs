using System.ComponentModel.DataAnnotations;

namespace HealthcareManager.Data.Models
{
    public class MedicationsModel: Base
    {
        [Key]
        public int MedicationId { get; set; }
        public string UserId { get; set; } = Guid.NewGuid().ToString();
        public string MedicationName { get; set; }
        public string MedicationDescription { get; set; }
        public List<string> MedicationType { get; set; }
        public int MedicationCount { get; set; }
        public List<ProviderModel> Provider { get; set; }
        public DateTime DatePrescribed { get; set; }
    }
}
