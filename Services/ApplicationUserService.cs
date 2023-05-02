using HospitalManagement.Data;
using HospitalManagement.Models;
using HospitalManagement.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

            //hash the password 
            string hashedPass = BCrypt.Net.BCrypt.HashPassword(addPatientVM.Password);

            //add and save user
            ApplicationUser newUser = new ApplicationUser()
            {
                FirstName = addPatientVM.FirstName,
                LastName = addPatientVM.LastName,
                Email = addPatientVM.Email,
                UserName = addPatientVM.Email,
                PasswordHash = hashedPass,
                SecurityStamp = Guid.NewGuid().ToString(),
            };

            Task<IdentityResult> result = _userManager.CreateAsync(newUser, hashedPass);
            Console.WriteLine("Result is: " + result.ToString());
            return result.Result;
        }

    }
}
