using System.ComponentModel.DataAnnotations;

namespace HealthcareManager.Components.Account.Shared.Models
{
    public class LookupCode
    {
        [StringLength(10)]
        public string Schema { get; set; }
        [StringLength(50)]
        public string Code {  get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(2000)]
        public string Description { get; set; }
        [StringLength(10)]
        public string Abbreviation { get; set; }
        public int? DisplayOrder { get; set; }
        public bool IsActive { get; set; }

    }
}
