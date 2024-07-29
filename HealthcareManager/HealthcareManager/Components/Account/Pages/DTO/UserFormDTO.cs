using HealthcareManager.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthcareManager.Components.Account.Pages.DTO
{
    public class UserFormDTO
    {
        [Key]
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
        public DateTime ? CreatedDate { get; set; }
        [Required(ErrorMessage = "Blood pressure is required")]
        public string? BloodPressure { get; set; }
        
        [Required(ErrorMessage = "Heart rate is required")]
        public int HeartRate { get; set; }
        [Required(ErrorMessage = "Temperature is required")]
        public double Temperature { get; set; }
        [Required(ErrorMessage = "Pulse Ox is required")]
        public int PulseOximetry { get; set; }
        [Required(ErrorMessage = "Height is required")]
        public int Height { get; set; }
        [Required(ErrorMessage = "Weight is required")]
        public long Weight { get; set; }
        public string Role { get; set; } = "Patient";
    }

    
}
