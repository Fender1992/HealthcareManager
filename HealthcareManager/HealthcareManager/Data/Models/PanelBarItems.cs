namespace HealthcareManager.Data.Models
{
    public class PanelBarItems
    {
        public string Id { get; set; }
        public string Section { get; set; }
        public string Abbreviation { get; set; }
        public IEnumerable<object> Data = new List<object>();
        public int Count { get; set; } = 0;
        public bool Disabled => Count == 0;
    }
}
