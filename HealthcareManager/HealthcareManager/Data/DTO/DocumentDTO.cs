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
        //protected override Func<IQueryable<HealthcareManager.Components.Account.Shared.Models.Document>, IQueryable<DocumentDTO>> Select => _documents => _documents.Select(_documents => new DocumentDTO
        //{
        //    Id = _documents.Id,
        //    FileName = _documents.FileName,
        //    FileContent = _documents.FileContent,
        //    FileLocation = _documents.FileLocation,
        //    Extension = _documents.Extension,
        //    IsArchived = _documents.IsArchived,
        //    DocumentCategoryId = _documents.DocumentCategoryId,
        //    DocumentTypeId = _documents.DocumentTypeId,
        //    DocumentCategory = _documents.DocumentCategory!.Name,
        //    DocumentType = _documents.DocumentType,
        //    CreatedDate = _documents.CreatedDate,
        //    LastModifiedDate = _documents.LastModifiedDate,
        //    TimeStamp = _documents.TimeStamp
        //});
    }
}
