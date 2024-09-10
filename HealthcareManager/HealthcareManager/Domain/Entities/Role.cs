namespace HealthcareManager.Domain.Entities
{
    public class Role : BaseEntity
    {
        public int RoleCodeId { get; set; }
        public LookupCode RoleCode { get; set; }
        public int? TypeCodeId { get; set; }
        public LookupCode? TypeCode { get; set; } = null;
        public int ModuleId { get; set; }
        public LookupCode Module {  get; set; }
        public int FacilityId { get; set; }
        public Facility Facility { get; set; }
    }
}
