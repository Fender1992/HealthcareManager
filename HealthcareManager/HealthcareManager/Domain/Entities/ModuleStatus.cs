namespace HealthcareManager.Domain.Entities
{
    public class ModuleStatus
    {
        public int? Id { get; set; }
        public LookupCode? LookupCode { get; set; }
        public int? SubModuleId { get; set; }
        public LookupCode? SubModule {  get; set; }
        public bool IsActive { get; set; }
    }
}
