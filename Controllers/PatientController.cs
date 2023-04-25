using Microsoft.AspNetCore.Mvc;
using HospitalManagement.Services;
using HospitalManagement.Models;

//todo: update to use ASP.Net authorization
namespace HospitalManagement.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PatientController : Controller
    {
        ////inject service
        //PatientService _patientService;

        //public PatientController (PatientService patientService) 
        //{ 
        //    _patientService = patientService;
        //}

        //[HttpGet("email")]
        //public ActionResult<Patient> GetPatientByEmail(string email) 
        //{ 
        //    var patient = _patientService.GetPatientEmail(email);

        //    if (patient != null) 
        //    {
        //        return patient;
        //    } 
        //    else
        //    {
        //        return NotFound();
        //    }
        //}

        //[HttpGet("id")]
        //public ActionResult<Patient> GetPatientById(string id)
        //{
        //    var patient = _patientService.GetPatientById(id);

        //    if (patient != null)
        //    {
        //        return patient;
        //    }
        //    else
        //    {
        //        return NotFound();
        //    }
        //}

        ////add doctor id to this
        //[HttpGet("name")]
        //public ActionResult<IEnumerable<Patient>> GetPatientByName(string firstName, string lastName) 
        //{
        //    var patient = _patientService.GetPatient(firstName, lastName);

        //    if (patient != null)
        //    {
        //        return Ok(patient);
        //    }
        //    else
        //    {
        //        return NotFound();
        //    }
        //}

        //[HttpPost("addPatient")]
        //public IActionResult AddPatient(Patient newPatient)
        //{
        //    var createdPatient = _patientService.CreatePatient(newPatient);
        //    return CreatedAtAction(nameof(GetPatientById), new { id = createdPatient.Id }, createdPatient);
        //}

        ////[HttPost("signIn")]
        ////public IActionResult PatientSignIn(string email, string password)
        ////{

        ////}
    }
}
