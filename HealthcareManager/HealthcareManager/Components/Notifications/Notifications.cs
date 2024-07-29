using BlazorBootstrap;

namespace HealthcareManager.Components.Notifications
{
    public class Notifications
    {
        private List<ToastMessage> messages = new List<ToastMessage>();
        public void ShowMessage(ToastType toastType) => messages.Add(UserCreatedSuccessNotification(toastType));
        public ToastMessage UserCreatedSuccessNotification(ToastType toastType)
        {
            var toastMessage = new ToastMessage();

            toastMessage.Type = toastType;
            toastMessage.Title = "Success";
            toastMessage.Message = "User succesfully created!";
            // disable auto hide for `danger` and `warning` messages.
            toastMessage.AutoHide = !(toastType == ToastType.Danger || toastType == ToastType.Warning);

            return toastMessage;
        }
    }
}
