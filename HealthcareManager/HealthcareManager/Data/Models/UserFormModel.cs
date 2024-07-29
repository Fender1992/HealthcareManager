using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthcareManager.Data.Models
{
    public class UserFormModel : Base
    {
        public int UserId { get; set; }
        [Required(ErrorMessage = "First name is required")]
        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters")]
        public string? FirstName { get; set; }
        [Required(ErrorMessage = "Last name is required")]
        [StringLength(75, ErrorMessage = "Last name cannot be longer than 75 characters")]
        public string? LastName { get; set; }
        [Required(ErrorMessage = "Address is required")]
        [StringLength(150, ErrorMessage = "Address cannot be longer than 150 characters")]
        public string? Address { get; set; }
        [Required(ErrorMessage = "Postal code is required")]
        public int PostalCode { get; set; }
        [Required(ErrorMessage = "Blood pressure is required")]
        public string? BloodPressure { get; set; }
        public int HeartRate { get; set; }
        public double Temperature { get; set; }
        public int PulseOximetry { get; set; }
        public int Height { get; set; }
        public long Weight { get; set; }
        public string Role { get; set; } 
    }
    
}
