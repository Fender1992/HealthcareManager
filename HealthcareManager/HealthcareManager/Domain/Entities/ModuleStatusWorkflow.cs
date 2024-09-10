namespace HealthcareManager.Domain.Entities
{
    public class ModuleStatusWorkflow : BaseEntity
    {
        public int? ModuleStatusId { get; set; }
        public ModuleStatus? ModuleStatus { get; set; }
        public int? ActionId { get; set; }
        public LookupCode? Action {  get; set; }
        public int? NextModuleStatusId { get; set; }
        public ModuleStatus? NextModuleStatus { get; set; }
        public bool IsActive { get; set; }
    }
}
