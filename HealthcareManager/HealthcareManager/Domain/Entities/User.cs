using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthcareManager.Domain.Entities
{
    public class User : BaseEntity
    {
        [StringLength(30)]
        public string FirstName { get; set; }
        [StringLength(30)]
        public string LastName { get; set; }
        [StringLength(100)]
        public string Email { get; set; }
        [StringLength(10)]
        public string? SSN { get; set; }
        [StringLength(20)]
        public string? PhoneNumber { get; set; }
        public int? FacilityId { get; set; }
        //public Facility? Facility { get; set; }
        public int? StatusId { get; set; }
        public List<UserRole>? UserRoles { get; set; }
        public List<UserPreference>? UserPreferences { get; set; }
        [NotMapped]
        public new int? CreatedByID { get; set; }
        [NotMapped]
        public new User? CreatedBy { get; set; }
        [NotMapped]
        public new int? LastModifiedById { get; set; }
        [NotMapped]
        public new User? LastModifiedBy { get; set; }

    }
}
