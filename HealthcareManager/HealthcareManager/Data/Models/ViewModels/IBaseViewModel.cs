namespace HealthcareManager.Data.Models.ViewModels
{
    public interface IBaseViewModel<T, U> where T : class where U : class
    {
        int? CreatedById { get; set; }
        int? LastModifiedById { get; set; }
        DateTime CreatedDate { get; set; }
        DateTime LastModifiedDate { get; set; }
        byte[] Timestamp { get; set; }
        static abstract T FromDTO(U _dto);
        static abstract U ToDTO(T _viewModel);
    }
}
