using System.Reflection.Metadata;

namespace HealthcareManager.Data.DTO
{
    public class DocumentDTO
    {
        public long Id { get; set; } = 0;
        public string FileName { get; set; }
        public byte[] FileContent { get; set; }
        public string FileLocation { get; set; }
        public string Extension { get; set; }
        public bool IsArchived { get; set; }
        public int? DocumentCategoryId { get; set; }
        public string DocumentCategory { get; set; }
        public int? DocumentTypeId { get; set; }
        public string? DocumentType { get; set; }

    //    protected override Func<IQueryable<Models.Document>, IQueryable<Models.Document>> Select =>
    //documents => documents.Select(document => new Models.Document
    //{
    //    Id = document.Id,
    //    FileName = document.FileName,
    //    FileContent = document.FileContent,
    //    FileLocation = document.FileLocation,
    //    Extension = document.Extension,
    //    IsArchived = document.IsArchived,
    //    DocumentCategoryId = document.DocumentCategoryId,
    //    DocumentTypeId = document.DocumentTypeId,

    //});
    }
}
