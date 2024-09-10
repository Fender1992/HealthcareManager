using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthcareManager.Domain.Entities
{
    public class UserPreference
    {
        [Key, ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }
        [ForeignKey("UserRole")]
        public int? UserRoleId { get; set; }
        public UserRole? UserRole { get; set; }
        public bool? RecieveEmail { get; set; }
        public int? DefaultSubModuleId { get; set; }
        public LookupCode? DefaultSubModule {  get; set; }
        [Timestamp]
        public byte[] Timestamp { get; set; }
    }
}
