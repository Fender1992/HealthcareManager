using HealthcareManager.Components.Account.Pages.DTO;
using HealthcareManager.Components.Account.Shared.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace HealthcareManager.Data.ViewModels
{
    public class UserFormViewModel : IBaseViewModel<UserFormViewModel, UserFormDTO>
    {
        public int UserId { get; set; }
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
        public int? CreatedById { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int? LastModifiedById { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime CreatedDate { get; set ; }
        public DateTime LastModifiedDate { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public byte[] Timestamp { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        private bool DisplayTabsOverride
        {
            get
            {
                return false;
            }
        }
        public static UserFormViewModel FromDTO(UserFormDTO dto)
        {
            return new UserFormViewModel
            {
                UserId = dto.UserId,
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

        public static UserFormDTO ToDTO(UserFormViewModel _viewModel)
        {
            return new UserFormDTO
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
