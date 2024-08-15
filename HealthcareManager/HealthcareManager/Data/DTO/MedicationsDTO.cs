using HealthcareManager.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace HealthcareManager.Data.DTO
{
    public class MedicationsDTO
    {
        [Key]
        public int MedicationId { get; set; }
        public string UserId { get; set; }
        public string MedicationName { get; set; }
        public string MedicationDescription { get; set; }
        public string MedicationType { get; set; }
        public int MedicationCount { get; set; }
        public DateTime DatePrescribed { get; set; }
       
    }
}
