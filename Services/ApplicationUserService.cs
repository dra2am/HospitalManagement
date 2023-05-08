using HospitalManagement.Data;
using HospitalManagement.Models;
using HospitalManagement.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BCryptNet = BCrypt.Net.BCrypt;

namespace HospitalManagement.Services
{
    public class ApplicationUserService
    {
        //dependency injection for context
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly HospitalContext _context;
        //get data from appsettings
        private readonly IConfiguration _configuration;

        public ApplicationUserService(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, HospitalContext context, IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
            _configuration = configuration;
        }
        public async Task<IdentityResult> CreateAppUser(AddPatientVM addPatientVM)
        {
            //check if user is unique (email must be unique)
            bool isUnique = await _userManager.FindByEmailAsync(addPatientVM.Email) == null ?
                true : false;

            if (!isUnique)
            {
                throw new Exception("ApplicationUserService.CreateAppUser: This user already exists in the system");
            }

            //add and save user
            ApplicationUser newUser = new ApplicationUser()
            {
                FirstName = addPatientVM.FirstName,
                LastName = addPatientVM.LastName,
                Email = addPatientVM.Email,
                UserName = addPatientVM.Email,
                PasswordHash = addPatientVM.Password,
                SecurityStamp = Guid.NewGuid().ToString(),
            };

            Task<IdentityResult> result = _userManager.CreateAsync(newUser, addPatientVM.Password);
            Console.WriteLine("Result is: " + result.ToString());
            return result.Result;
        }

        public async Task<bool> LoginAppUser(LoginPatientVM loginPatientVM)
        {
            //check if user exists (email and username are the same in this case)
            var user = await _userManager.FindByEmailAsync(loginPatientVM.UserName);

            //if user exists, check password. If not, return false.
            if (user == null)
            {
                return false;
            }

            bool doesMatch = await _userManager.CheckPasswordAsync(user, loginPatientVM.Password);

            if (!doesMatch)
            {
                return false;
            }

            return true;

        }

    }
}
