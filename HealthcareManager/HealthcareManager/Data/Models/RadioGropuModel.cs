namespace HealthcareManager.Data.Models
{
    public class RadioGropuModel<T, U> where T : class where U : class
    {
        public T Value { get; set; }
        public U Text { get; set; }
    }
}
