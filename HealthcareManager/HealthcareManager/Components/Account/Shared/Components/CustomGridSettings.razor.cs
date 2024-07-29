using HealthcareManager.Components.Account.Shared.Models;
using Microsoft.AspNetCore.Components;

namespace HealthcareManager.Components.Account.Shared.Components
{
    public partial class CustomGridSettings
    {
        public CustomGridSettings() { }
        public CustomGridSettings(GridSettingsModel m)
        {
            Settings = m;
        }
        [Parameter]
        public GridSettingsModel Settings { get; set; } = new GridSettingsModel();
        protected override void OnInitialized()
        {
            base.OnInitialized();
        }
    }
}
