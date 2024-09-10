using HealthcareManager.Data.DTO;

namespace HealthcareManager.Data.Models.ViewModels
{
    public class DocumentViewModel : IBaseViewModel<DocumentViewModel, DocumentDTO>
    {
        public int? CreatedById { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int? LastModifiedById { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime CreatedDate { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime LastModifiedDate { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public byte[] Timestamp { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public static DocumentViewModel FromDTO(DocumentDTO _dto)
        {
            throw new NotImplementedException();
        }

        public static DocumentDTO ToDTO(DocumentViewModel _viewModel)
        {
            throw new NotImplementedException();
        }
    }
}
