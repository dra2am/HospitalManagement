using Microsoft.AspNetCore.Mvc;
using HospitalManagement.Services;
using HospitalManagement.Models;

namespace HospitalManagement.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PatientController : ControllerBase
    {
        //inject service
        PatientService _patientService;

        public PatientController (PatientService patientService) 
        { 
            _patientService = patientService;
        }

        [HttpGet("email/{email}")]
        public ActionResult<Patient> GetPatientByEmail(string email) 
        { 
            var patient = _patientService.GetPatientEmail(email);

            if (patient != null) 
            {
                return patient;
            } 
            else
            {
                return NotFound();
            }
        }

        [HttpGet("id/{id}")]
        public ActionResult<Patient> GetPatientById(int id)
        {
            var patient = _patientService.GetPatientById(id);

            if (patient != null)
            {
                return patient;
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("name/{first}/{last}")]
        public ActionResult<IEnumerable<Patient>> GetPatientByName(string firstName, string lastName) 
        {
            var patient = _patientService.GetPatient(firstName, lastName);

            if (patient != null)
            {
                return Ok(patient);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost("addPatient")]
        public IActionResult AddPatient(Patient newPatient)
        {
            //checks if Form values are bound to the Model + if model validations pass
            //if (!ModelState.IsValid){}

            var createdPatient = _patientService.CreatePatient(newPatient);
            return CreatedAtAction(nameof(GetPatientById), new { id = createdPatient.PatientId }, createdPatient);
        }
    }
}
