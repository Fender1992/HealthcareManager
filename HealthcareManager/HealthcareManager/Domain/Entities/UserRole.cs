namespace HealthcareManager.Domain.Entities
{
    public class UserRole : BaseEntity
    {
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public bool IsAuthorized { get; set; }
    }
}
