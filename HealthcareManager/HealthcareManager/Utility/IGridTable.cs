using Telerik.Blazor.Components;

namespace HealthcareManager.Utility
{
    public interface IGridTable
    {
        Task OnAddHandler(GridCommandEventArgs e);
        Task OnCreateHandler(GridCommandEventArgs e);
        Task OnEditHandler(GridCommandEventArgs e);
        Task OnUpdateHandler(GridCommandEventArgs e);
        Task OnDeleteHandler(GridCommandEventArgs e);
        Task OnCancelHandler(GridCommandEventArgs e);
    }
}
