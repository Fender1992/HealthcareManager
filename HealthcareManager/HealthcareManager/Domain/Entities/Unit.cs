using System.ComponentModel.DataAnnotations;

namespace HealthcareManager.Domain.Entities
{
    public class Unit : BaseEntity
    {
        public int? FacilityId { get; set; }
        public Facility? Facility { get; set; }
        [StringLength(60)]
        public string UnitName { get; set; }
    }
}
