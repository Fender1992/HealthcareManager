using Telerik.Blazor;

namespace HealthcareManager.Data.Models
{
    public class GridSettingsModel
    {
        public string? Class { get; set; } = "";
        public string? Title { get; set; } = "";
        public string? Width { get; set; }
        public string? MaxWidth { get; set; }
        public string? MinWidth { get; set; }
        public string? Height { get; set; }
        public string? MaxHeight { get; set; }
        public string? MinHeight { get; set; }
        public FormButtonsLayout ButtonLayout { get; set; } = FormButtonsLayout.Stretch;
        public int Columns { get; set; } = 2;
        public int ColumnSpacing { get; set; } = 4;
        public FormOrientation Orientation { get; set; } = FormOrientation.Vertical;
    }
    public enum FormButtonsLayout
    {
        Start,
        Center,
        End,
        Stretch
    }
}
