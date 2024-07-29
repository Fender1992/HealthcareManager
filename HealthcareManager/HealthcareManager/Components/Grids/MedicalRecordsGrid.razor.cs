using BlazorBootstrap;
using HealthcareManager.Components.Account.Pages.DTO;
using HealthcareManager.Components.Account.Shared.Components;
using HealthcareManager.Components.Base;
using HealthcareManager.Data;
using HealthcareManager.Data.Repositories;
using Microsoft.AspNetCore.Components;


namespace HealthcareManager.Components.Grids
{
    public partial class MedicalRecordsGrid: OwningComponentBase
    {
        private ApplicationDbContext dbContext;
        [Inject]
        protected ILogger<MedicalRecordsGrid> Logger { get; set; }
        [CascadingParameter]
        private AppState? AppState { get; set; }
        [CascadingParameter]
        public string View {  get; set; }
        [Parameter]
        public IList<UserFormDTO> Data { get; set; }
        [Parameter]
        public int PageSize {  get; set; }
        [Parameter]
        public string Parent { get; set; }
        [Parameter]
        public bool UsingModal { get; set; }
        [Parameter]
        public EventCallback GridVisibileChanged { get; set; }
        [Parameter]
        public EventCallback AddNewEncounterPromptAsync { get; set; }
        [Parameter]
        public EventCallback RefreshModelsCallBack { get; set; }
        [Parameter]
        public EventCallback RefreshTabStrip {  get; set; }
        [Parameter]
        public UserFormDTO CurrentVM { get; set; } = new UserFormDTO();
        [Parameter]
        public EventCallback<UserFormDTO> CurrentVMChanged { get; set; }
        [Parameter]
        public EventCallback GetDocumentsHandler { get; set; }
        [Parameter]
        public EventCallback<Tuple<string,string>> MoveRecordHandler { get; set; }
        public GridSettings Settings { get; set; } = new GridSettings();
        public CustomGridTable<UserFormDTO> Grid {  get; set; }
        public bool ShowSubmit { get; set; } = false;
        private bool ShowReturn { get; set; } = false;
        private bool IsInfo { get; set; } = false;
        private string ModalAction { get; set; } = "";
        private readonly SQLMedicalRecordsRepository _repository;

      
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);
        }

        public async Task GetAllAsync(SQLMedicalRecordsRepository sQLMedicalRecordsRepository)
        {
            List<UserFormDTO> _Records = new List<UserFormDTO>();
            if (!AppState.CurrentUser.Role.Contains("User"))
            {
                _Records = await _repository.GetAllRecordsAsync();
            }

        }
    }
}
