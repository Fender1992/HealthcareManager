using HealthcareManager.Data;
using HealthcareManager.Data.DTO;
using HealthcareManager.Data.Models;
using HealthcareManager.Repositories.AppointmentsRepository;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace HealthcareManager.Components.Account.Pages.Components.Forms.CustomForms
{
    public partial class NewAppointmentForm
    {
        private ApplicationDbContext _context;
        private IAppointmentRepository<AppointmentDTO> _apptRepo;

        [Inject]
        private ILogger<NewAppointmentForm> Logger { get; set; }

        [Inject]
        private NavigationManager NavigationManager { get; set; }

        private List<AppointmentDTO> Appointments { get; set; } = new List<AppointmentDTO>();
        private AppointmentDTO newAppointment { get; set; } = new AppointmentDTO();
        private ApplicationUser user { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Appointments = await _apptRepo.GetAllAsync();
            await base.OnInitializedAsync();
        }

        private async Task SubmitForm()
        {
            if (newAppointment != null)
            {
                try
                {
                    string currUser = user.UserId.ToString();
                    await _apptRepo.AddAsync(newAppointment, currUser);
                    Appointments.Add(newAppointment);

                    await _context.SaveChangesAsync();

                    NavigationManager.NavigateTo("/Account/manage-appointments");
                }
                catch (Exception e)
                {
                    Logger.LogError(e, e.Message);
                }
            }
        }
    }
}
