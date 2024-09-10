using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthcareManager.Domain.Entities
{
    [Table("Facility", Schema = "f")]
    public class Facility: BaseEntity
    {
        public int? ParentFacilityId { get; set; }
        public Facility? ParentFacility { get; set; }
        [StringLength(3)]
        public string StateAbbreviation { get; set; }
        [StringLength(50)]
        public string FacilityName { get; set; }
        [StringLength(5)]
        public string? ProgramId { get; set; }
        public int? FacilityCodeId { get; set; }
        public LookupCode? FacilityCode { get; set; }
        public int? DefaultFacilityCode { get; set; }
        public LookupCode? DefaultStatusCode { get; set; }
        public string? SpecialAreaCode { get; set; }
        public bool? IsActive { get; set; }
        public List<Unit>? Departments { get; set; }
        public List<ModuleStatusWorkflow>? Workflows { get; set; }


        

    }
}
