using HealthcareManager.Data.DTO;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace HealthcareManager.Data.Models.ViewModels
{
    public class UserFormViewModel : IBaseViewModel<UserFormViewModel, ApplicationUserDTO>
    {
        public string UserId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Address { get; set; }
        public int PostalCode { get; set; }
        public string? BloodPressure { get; set; }
        public int HeartRate { get; set; }
        public double Temperature { get; set; }
        public int PulseOximetry { get; set; }
        public int Height { get; set; }
        public long Weight { get; set; }
        [HiddenInput]
        public int? CreatedById { get; set; }
        [HiddenInput]
        public int? LastModifiedById { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastModifiedDate { get; set; }
        [HiddenInput]
        public byte[] Timestamp { get; set; }

        private bool DisplayTabsOverride
        {
            get
            {
                return false;
            }
        }
        public static UserFormViewModel FromDTO(ApplicationUserDTO dto)
        {
            return new UserFormViewModel
            {
                UserId = dto.UserId.ToString(),
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Address = dto.Address,
                PostalCode = dto.PostalCode,
                BloodPressure = dto.BloodPressure,
                HeartRate = dto.HeartRate,
                Temperature = dto.Temperature,
                Height = dto.Height,
                Weight = dto.Weight,
                PulseOximetry = dto.PulseOximetry,
                CreatedDate = (DateTime)dto.CreatedDate,

            };
        }

        public static ApplicationUserDTO ToDTO(UserFormViewModel _viewModel)
        {
            return new ApplicationUserDTO
            {
                UserId = _viewModel.UserId,
                FirstName = _viewModel.FirstName,
                LastName = _viewModel.LastName,
                Address = _viewModel.Address,
                PostalCode = _viewModel.PostalCode,
                BloodPressure = _viewModel.BloodPressure,
                HeartRate = _viewModel.HeartRate,
                Temperature = _viewModel.Temperature,
                Height = _viewModel.Height,
                Weight = _viewModel.Weight,
                PulseOximetry = _viewModel.PulseOximetry,
                CreatedDate = _viewModel.CreatedDate,
            };
        }
    }
}
