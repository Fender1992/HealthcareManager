using Microsoft.AspNetCore.Components;

namespace HealthcareManager.Components.Account.Shared.Components
{
    public partial class Icon : ComponentBase
    {
        [Parameter]
        public string IconSet { get; set; }
        [Parameter]
        public string IconName { get; set; }
        [Parameter]
        public string? IconColor { get; set; }
        [Parameter]
        public string? IconSize { get; set; } = "1x";
        [Parameter]
        public string? AdditionalClasses { get; set; } = "";
        internal string OutputClass { get; set; } = "";
        public Icon() { }
        
        public Icon(string iconSet, string iconName, string? iconColor, string? iconSize)
        {
            IconSet = iconSet;
            IconName = iconName;
            IconColor = iconColor;
            IconSize = iconSize;
            OutputClass = $"fa {(!string.IsNullOrEmpty(IconSet) ? $"fa-{IconSet}" : "")} {(!string.IsNullOrEmpty(IconName) ? $"fa-{IconName}" : "")} {(!string.IsNullOrEmpty(IconColor) ? $"fac-{IconColor}" : "")} {(!string.IsNullOrEmpty(IconSize) ? $"fa-{IconSize}" : "")} {AdditionalClasses}";
        }
        protected override void OnInitialized()
        {
            OutputClass = $"fa {(!string.IsNullOrEmpty(IconSet) ? $"fa-{IconSet}" : "")} {(!string.IsNullOrEmpty(IconName) ? $"fa-{IconName}" : "")} {(!string.IsNullOrEmpty(IconColor) ? $"fac-{IconColor}" : "")} {(!string.IsNullOrEmpty(IconSize) ? $"fa-{IconSize}" : "")} {AdditionalClasses}";
        }
    }
}
