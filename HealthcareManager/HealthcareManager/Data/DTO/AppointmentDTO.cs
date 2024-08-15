namespace HealthcareManager.Data.DTO
{
    public class AppointmentDTO
    {
        public int Id { get; set; }
        public string UserId { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }
        public string Description { get; set; }
        public DateOnly Date { get; set; }
        public TimeOnly Time { get; set; }
    }
}
