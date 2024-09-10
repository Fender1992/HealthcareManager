using HealthcareManager.Data.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;
using Telerik.SvgIcons;
using HealthcareManager.Data;

namespace HealthcareManager.Components.Account.Shared.Components
{
    public partial class MainNav : OwningComponentBase
    {
        [Inject]
        private NavigationManager NavigationManager {  get; set; }
        public List<NavigationItem> NavigationItems { get; set; }
        [CascadingParameter]
        private AppState? AppState { get; set; }
        private bool showLanding {  get; set; } = true;
        private bool showAdmin { get; set; } = true;
        private bool showProfile { get; set; } = true;

        protected override void Dispose(bool disposing)
        {
            AppState._OnChange -= StateHasChanged;
            NavigationManager.LocationChanged -= SetSelectNavItemChanged;
            base.Dispose(disposing);
        }
        protected override async Task OnInitializedAsync()
        {
            NavigationManager.LocationChanged += SetSelectNavItemChanged;
            AppState._OnChange += StateHasChanged;
            if(AppState._currentUser != null)
            {
                showLanding = true;
                showProfile = false;
            }
            else
                showLanding = showAdmin = showProfile = true;
                
            NavigationItems = GetNavItems;
            await base.OnInitializedAsync();
        }

        private List<NavigationItem> GetNavItems => new List<NavigationItem>
        {
            new NavigationItem()
        };
        public object FontAwesome { get; private set; }

        private void SetSelectNavItemChanged(object sender, LocationChangedEventArgs e)
        {
            string url = NavigationManager.Uri.Substring(NavigationManager.BaseUri.Length - 1);
            if(NavigationItems != null)
            {
                if(NavigationItems.Any(x => x.IsActive))
                {
                    NavigationItems.Find(x => x.IsActive)!.IsActive = false;
                }
                foreach(NavigationItem item in NavigationItems)
                {
                    if(item.Url == url)
                    {
                        item.IsActive = true;
                    }
                    else
                    {
                        item.IsActive = false;
                    }
                }
            }
        }
        //private void LogoutUser()
        //{
        //    AppState.ClearCurrentUser();
        //    AppState.SetSessionAsync<bool>("Logout", true);
        //    NavigationManager.NavigateTo("/", true);
        //}
    }
    
}
