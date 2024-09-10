using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthcareManager.Domain.Entities
{
    public class Document : BaseEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public new long Id { get; set; }
        [StringLength(255)]
        public string FileName {  get; set; }
        public byte[]? FileCOntent { get; set; }
        [StringLength(5000)]
        public string? FileLocation { get; set; }
        [StringLength(5)]
        public string Extension { get; set; }
        public bool IsArchived { get; set; }
        public int? DocumentCategoryId { get; set; }
        public LookupCode? DocumentCategory {  get; set; }
        public int? DocumentTypeId { get; set; }
        public LookupCode? DocumentType { get; set; }
    }
}
