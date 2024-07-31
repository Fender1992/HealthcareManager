using Telerik.Blazor;
using Telerik.Blazor.Components;

namespace HealthcareManager.Utility
{
    public class NotificationUtility
    {
        public NotificationUtility(TelerikNotification _reference)
        {
            NotificationReference = _reference;
        }
        public TelerikNotification NotificationReference { get; set; }
        public void SuccessNotification(string text)
        {
            NotificationReference.Show(new SuccessNotificationModel(text));
        }
        public void InfoNotification(string text)
        {
            NotificationReference.Show(new InfoNotificationModel(text));
        }
        public void WarningNotification(string text)
        {
            NotificationReference.Show(new WarningNotificationModel(text));
        }
        public void ErrorNotification(string text)
        {
            NotificationReference.Show(new ErrorNotificationModel(text));
        }
        public class SuccessNotificationModel : NotificationModel
        {
            public SuccessNotificationModel(string text)
            {
                Text = text;
                ThemeColor = ThemeConstants.Notification.ThemeColor.Success;
                CloseAfter = 5000;
                Closable = false;
                ShowIcon = true;
            }
        }
        public class InfoNotificationModel : NotificationModel
        {
            public InfoNotificationModel(string text)
            {
                Text = text;
                ThemeColor = ThemeConstants.Notification.ThemeColor.Info;
                CloseAfter = 5000;
                Closable = false;
                ShowIcon = true;
            }
        }
        public class WarningNotificationModel : NotificationModel
        {
            public WarningNotificationModel(string text)
            {
                Text = text;
                ThemeColor = ThemeConstants.Notification.ThemeColor.Warning;
                CloseAfter = 5000;
                Closable = false;
                ShowIcon = true;
            }
        }
        public class ErrorNotificationModel : NotificationModel
        {
            public ErrorNotificationModel(string text)
            {
                Text = text;
                ThemeColor = ThemeConstants.Notification.ThemeColor.Error;
                CloseAfter = 5000;
                Closable = false;
                ShowIcon = true;
            }
        }
    }
}
