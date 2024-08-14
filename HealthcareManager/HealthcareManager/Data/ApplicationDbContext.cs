using HealthcareManager.Data.DTO;
using HealthcareManager.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HealthcareManager.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<UserFormDTO>? userForm { get; set; }
        public DbSet<ProviderModelDto> Providers
        {
            get; set;
        }
        public DbSet<AppointmentDTO> Appointments { get; set; }
        public DbSet<MedicationsDTO> Medications { get; set; }
    }
}
