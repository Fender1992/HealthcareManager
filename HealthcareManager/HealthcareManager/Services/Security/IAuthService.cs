using HealthcareManager.Data.DTO;

namespace HealthcareManager.Services.Security
{
    public interface IAuthService
    {
        Task<bool> CheckNotAuthorizedForModule(Type t, ApplicationUserDTO CurrentUser, string module = "");
        Task<bool> CheckNotAuthorizedForView(Type t, ApplicationUserDTO CurrentUser, string module = "", string view = "");
        Task<bool> CheckNotAuthorizedToEdit(ApplicationUserDTO CurrentUser, string module = "");
        Task<bool> CheckNotAuthorizedForDocumentEdit(ApplicationUserDTO CurrentUser, string view, string documentStatus);
        Task<bool> CheckNotAuthorizedForDelete(ApplicationUserDTO CurrentUser, string module = "");
        void Dispose();
    }
    public class AuthService : IAuthService, IDisposable
    {
        public Task<bool> CheckNotAuthorizedForDelete(ApplicationUserDTO CurrentUser, string module = "")
        {
            throw new NotImplementedException();
        }

        public Task<bool> CheckNotAuthorizedForDocumentEdit(ApplicationUserDTO CurrentUser, string view, string documentStatus)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CheckNotAuthorizedForModule(Type t, ApplicationUserDTO CurrentUser, string module = "")
        {
            throw new NotImplementedException();
        }

        public Task<bool> CheckNotAuthorizedForView(Type t, ApplicationUserDTO CurrentUser, string module = "", string view = "")
        {
            throw new NotImplementedException();
        }

        public Task<bool> CheckNotAuthorizedToEdit(ApplicationUserDTO CurrentUser, string module = "")
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
