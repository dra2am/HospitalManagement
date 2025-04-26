using HospitalManagement.Models.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace HospitalManagement.Services
{
    public interface IApplicationUserService
    {
        Task<IdentityResult> CreateAppUser(AddPatientVM addPatientVM);
        Task<bool> LoginAppUser(LoginPatientVM loginPatientVM);
    }
}
