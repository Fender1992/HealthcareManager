using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthcareManager.Data.Models
{
    public class Document
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string UserId { get; set; } = Guid.NewGuid().ToString();
        [StringLength(255)]
        public string FileName { get; set; }
        public byte[]? FileContent { get; set; }
        [StringLength(5000)]
        public string? FileLocation { get; set; }
        [StringLength(5)]
        public string Extension { get; set; }
        public bool IsArchived { get; set; }
        public int? DocumentCategoryId { get; set; }
        public int? DocumentTypeId { get; set; }
        //public LookupCode? DocumentType { get; set; }
    }
}
