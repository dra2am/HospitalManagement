using HospitalManagement.Models.ViewModels;
using HospitalManagement.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;


namespace HospitalManagement.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApplicationUserController : Controller
    {
        //inject service
        ApplicationUserService _applicationUserService;

        public ApplicationUserController(ApplicationUserService applicationUserService)
        {
            _applicationUserService = applicationUserService;
        }

        [HttpPost("addUser")]
        public IActionResult CreateAppUser([FromBody] AddPatientVM addPatientVM)
        {
            if (!ModelState.IsValid) 
            {
                return BadRequest("ApplicationUserController.CreateAppUser: model is invalid");
            }

            try
            {
                Task<IdentityResult> result = _applicationUserService.CreateAppUser(addPatientVM);

                if(!result.Result.Succeeded)
                {
                    return BadRequest("ApplicationUserController.CreateAppUser: unable to create patient");
                }
                
                
                //todo: if result is valid, add patient data from patientVM into patient table

                return Ok("Patient created");

            } catch (Exception ex) 
            {
                Console.WriteLine("Exception in ApplicationUserController.CreateAppUser: " + ex);
                return BadRequest(ex.Message);
            }
        }


    }
}
