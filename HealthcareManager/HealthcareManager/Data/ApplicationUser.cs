using HealthcareManager.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HealthcareManager.Data
{
    public class UserIdentity : IdentityUser
    {
        public int Id { get; set; }
        [Key]
        public string UserId { get; set; } = Guid.NewGuid().ToString();
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
        public int SSN { get; set; }
        public DateTime? CreatedDate { get; set; }
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
        public int? FacilityId { get; set; }
        public Facility? Facility { get; set; }
        public int? StatusId { get; set; }
        public List<UserRole>? UserRoles { get; set; }
        public List<UserPreference>? UserPreferences { get; set; }
        [NotMapped]
        public new int CreatedById { get; set; }
        [NotMapped]
        public new User? CreatedBy { get; set; }
        [NotMapped]
        public new int? LastModifiedById { get; set; }
        [NotMapped]
        public new User? LastModifiedBy { get; set; }
    }
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : BaseEntity
    {
        public int Id { get; set; }
        [Key]
        public string UserId { get; set; } = Guid.NewGuid().ToString();
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
        public int SSN { get; set; }
        public DateTime? CreatedDate { get; set; }
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
        public int? FacilityId { get; set; }
        public Facility? Facility { get; set; }
        public int? StatusId { get; set; }
        public List<UserRole>? UserRoles { get; set; }
        public List<UserPreference>? UserPreferences { get; set; }
        [NotMapped]
        public new int CreatedById { get; set; }
        [NotMapped]
        public new User? CreatedBy { get; set; }
        [NotMapped]
        public new int? LastModifiedById { get; set; }
        [NotMapped]
        public new User? LastModifiedBy { get; set; }
    }
}
