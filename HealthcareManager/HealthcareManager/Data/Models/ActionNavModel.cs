namespace HealthcareManager.Data.Models
{
    public class ActionNavModel
    {
        public string Text { get; set; }
        public string TelerikIcon { get; set; }
        public string Action { get; set; }
        public List<ActionNavModel>? Items { get; set; }
    }
}
