using HealthcareManager.Components.Account.Shared.Components;

namespace HealthcareManager.Data.Models
{
    public class NavigationItem
    {
        public string? Text { get; set; }
        public string? Url { get; set; }
        public Icon? Icon { get; set; }
        public string? ImageUrl { get; set; }
        public bool IsHeaderImage { get; set; }
        public bool IsSeparator {  get; set; }
        public bool IsEnabled { get; set; }
        public bool IsActive { get; set; } = false;
        public NavigationItem() { }
        
        public NavigationItem(string _text, string _url, Icon? _icon)
        {
            Text = _text;
            Url = _url;
            Icon = _icon;
        }
        public NavigationItem(bool _isHeaderImage, string _url, string _imageUrl)
        {
            IsHeaderImage = _isHeaderImage;
            Url = _url;
            ImageUrl = _imageUrl;
        }
        public NavigationItem(bool _isSeparator)
        {
            IsSeparator = _isSeparator;
        }
    }
}
