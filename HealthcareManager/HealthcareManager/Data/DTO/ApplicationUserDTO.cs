using HealthcareManager.Data.Models;
using HealthcareManager.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthcareManager.Data.DTO
{
    public class ApplicationUserDTO : BaseDTO<ApplicationUser>
    {
        public int Id { get; set; } 
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

        public ICollection<UserRole> Roles { get; set; } = new List<UserRole>();
        public int? FacilityId { get; set; }
        public Facility? Facility { get; set; }
        public int? StatusId { get; set; }
        public List<UserRole>? UserRoles { get; set; } = new List<UserRole>();
        public List<UserPreference>? UserPreferences { get; set; }

        [NotMapped]
        public int CreatedById { get; set; }

        [NotMapped]
        public User? CreatedBy { get; set; }

        [NotMapped]
        public int? LastModifiedById { get; set; }

        [NotMapped]
        public User? LastModifiedBy { get; set; }

        public DateTime LastModifiedDate => throw new NotImplementedException();

        public byte[] TimeStamp => throw new NotImplementedException();

        protected override Func<IQueryable<ApplicationUser>, IQueryable<ApplicationUser>> Select => throw new NotImplementedException();

        protected override Func<IQueryable<ApplicationUser>, IQueryable<ApplicationUser>> SelectSlim => throw new NotImplementedException();


        // Manual mapping method from ApplicationUser to ApplicationUserDTO
        public override ApplicationUserDTO FromEntity(ApplicationUser user)
        {
            return new ApplicationUserDTO
            {
                UserId = user.UserId,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Address = user.Address,
                BloodPressure = user.BloodPressure,
                HeartRate = user.HeartRate,
                Height = user.Height,
                Weight = user.Weight,
                PostalCode = user.PostalCode,
                Facility = user.Facility,
                FacilityId = user.FacilityId,
                UserPreferences = user.UserPreferences,
                StatusId = user.StatusId,
                CreatedBy = user.CreatedBy,
                LastModifiedBy = user.LastModifiedBy,
                LastModifiedById = user.LastModifiedById,
                CreatedById = user.CreatedById,
                PulseOximetry = user.PulseOximetry,
                Temperature = user.Temperature,
                SSN = user.SSN,
                CreatedDate = user.CreatedDate
            };
        }

        // Manual mapping method from ApplicationUserDTO to ApplicationUser
        protected override ApplicationUser ToEntity<ApplicationUserDTO>()
        {
            return new ApplicationUser
            {
                UserId = this.UserId,
                FirstName = this.FirstName,
                LastName = this.LastName,
                Address = this.Address,
                BloodPressure = this.BloodPressure,
                HeartRate = this.HeartRate,
                Height = this.Height,
                Weight = this.Weight,
                PostalCode = this.PostalCode,
                Facility = this.Facility,
                FacilityId = this.FacilityId,
                UserPreferences = this.UserPreferences,
                StatusId = this.StatusId,
                CreatedBy = this.CreatedBy,
                LastModifiedBy = this.LastModifiedBy,
                LastModifiedById = this.LastModifiedById,
                CreatedById = this.CreatedById,
                PulseOximetry = this.PulseOximetry,
                Temperature = this.Temperature,
                SSN = this.SSN,
                CreatedDate = this.CreatedDate
            };
        }
    }
}
