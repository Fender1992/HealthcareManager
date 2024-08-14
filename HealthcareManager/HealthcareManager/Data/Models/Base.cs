namespace HealthcareManager.Data.Models
{
    public class Base
    {
        public Guid Id { get; set; } // Unique identifier
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedDate { get; set; } = DateTime.UtcNow;
        public string? CreatedBy { get; set; } // User who created the entity
        public string? UpdatedBy { get; set; } // User who last updated the entity
        public bool IsActive { get; set; }
        public bool isEditable { get; set; }

    }
}
