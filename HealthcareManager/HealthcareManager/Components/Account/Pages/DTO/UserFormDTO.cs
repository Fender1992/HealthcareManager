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

        [NotMapped]
        public string? BloodPressure
        {
            get => $"{BloodPressureSystolic}/{BloodPressureDiastolic}";
            set
            {
                var values = value?.Split('/');
                if (values?.Length == 2 &&
                    int.TryParse(values[0], out var systolic) &&
                    int.TryParse(values[1], out var diastolic))
                {
                    BloodPressureSystolic = systolic;
                    BloodPressureDiastolic = diastolic;
                }
            }
        }

        [Required(ErrorMessage = "Systolic blood pressure is required")]
        public int BloodPressureSystolic { get; set; }

        [Required(ErrorMessage = "Diastolic blood pressure is required")]
        public int BloodPressureDiastolic { get; set; }
        public int HeartRate { get; set; }
        public double Temperature { get; set; }
        public int PulseOximetry { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public Roles Role { get; set; } = Roles.User;
    }

    
}
