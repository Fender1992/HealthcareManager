using HealthcareManager.Data.DTO;
using HealthcareManager.Data.Models;
using HealthcareManager.Domain.Entities;
using Microsoft.AspNetCore.DataProtection.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace HealthcareManager.Data
{
    public class ApplicationDbContext : DbContext, IDataProtectionKeyContext
    {
        public ApplicationDbContext()
        {
        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public async Task<int> SaveChangesAsync() { return await base.SaveChangesAsync(); }
        public async Task SetChangeTracker(QueryTrackingBehavior behavior) { this.ChangeTracker.QueryTrackingBehavior = behavior; }
        public bool IsDisposed()
        {
            bool r = true;
            Type? typeContext = typeof(ApplicationDbContext);
            FieldInfo? isDisposedField = typeContext.GetField("_disposed", BindingFlags.NonPublic | BindingFlags.Instance);

            if (isDisposedField != null)
            {
                r = (bool)isDisposedField.GetValue(this);
            }
            return r;
        }

        public DbSet<ApplicationUserDTO>? UserForm { get; set; }
        public DbSet<ProviderModelDto> Providers
        {
            get; set;
        }
        public DbSet<AppointmentDTO> Appointments { get; set; }
        public DbSet<MedicationsDTO> Medications { get; set; }
        public DbSet<Facility> Facilities { get; set; }
        public DbSet<Role> roles {  get; set; }
        public DbSet<UserPreference> userPreferences { get; set; }
        //public DbSet<DocumentDTO> Documents { get; set; }
        public DbSet<UserRole> Useroles {  get; set; }

        public DbSet<DataProtectionKey> DataProtectionKeys { get; set; } = null!;

        //public DbSet<Unit> units { get; set; }
        //public DbSet<LookupCode> lookupCodes { get; set; }
        //public DbSet<ModuleStatus> moduleStatus { get; set; }
        //public DbSet<ModuleStatusWorkflow> moduleStatusWorkflow { get; set; }

        public void Initialize()
        {
            this.Database.EnsureCreated();
            this.Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure the many-to-many relationship between User and UserRole
            modelBuilder.Entity<User>()
                .HasMany(u => u.UserRoles)
                .WithOne(ur => ur.User)
                .HasForeignKey(ur => ur.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.User)
                .WithMany(u => u.UserRoles)
                .HasForeignKey(ur => ur.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Role>()
                .HasOne(r => r.RoleCode)
                .WithMany()
                .HasForeignKey(r => r.RoleCodeId)
                .OnDelete(DeleteBehavior.Restrict); // Avoid cascading to prevent cycles

            modelBuilder.Entity<Role>()
                .HasOne(r => r.TypeCode)
                .WithMany()
                .HasForeignKey(r => r.TypeCodeId)
                .OnDelete(DeleteBehavior.Restrict); // Avoid cascading to prevent cycles

            modelBuilder.Entity<Role>()
                .HasOne(r => r.Module)
                .WithMany()
                .HasForeignKey(r => r.ModuleId)
                .OnDelete(DeleteBehavior.Restrict); // Avoid cascading to prevent cycles

            modelBuilder.Entity<Role>()
                .HasOne(r => r.Facility)
                .WithMany()
                .HasForeignKey(r => r.FacilityId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
