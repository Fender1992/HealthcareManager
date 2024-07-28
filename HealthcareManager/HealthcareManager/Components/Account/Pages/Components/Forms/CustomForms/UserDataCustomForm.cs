using HealthcareManager.Components.Base;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System.Diagnostics.CodeAnalysis;

namespace HealthcareManager.Components.Account.Pages.Components.Forms.CustomForms
{
    public partial class UserDataCustomForm : OwningComponentBase
    {
        [Inject]
        protected ILogger<UserDataCustomForm>? Logger { get; set; }
        [Inject]
        private NavigationManager? NavigationManager { get; set; }
        [Parameter]
        public bool CanEdit { get; set; } = false;
        [Parameter]
        public bool? ShowSave { get; set; }
        [Parameter, AllowNull]
        public string Class { get; set; } = "";
        [Parameter]
        public RenderFragment? FromControls { get; set; }
        [Parameter, AllowNull]
        public RenderFragment FormButtons { get; set; }
        [Parameter]
        public EditContext? Context { get; set; }
        [Parameter]
        public EventCallback<EditContext> ValidSubmitHandler { get; set; }
        [Parameter]
        public EventCallback<EditContext> SubmitHandler { get; set; }
        [CascadingParameter]
        private AppState? AppState { get; set; }
        protected override async Task OnInitializedAsync()
        {
            if (ShowSave is null)
                ShowSave = true;
            await base.OnInitializedAsync();
        }
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);
        }
        protected async Task Submit(EditContext context)
        {
            bool valid = context.Validate();
            
            if(valid)
                await ValidSubmitHandler.InvokeAsync(context);
          
        }

    }
}
