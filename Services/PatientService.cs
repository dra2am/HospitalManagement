using HospitalManagement.Data;
using HospitalManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagement.Services
{
    public class PatientService
    {
        //dependency injection for context
        private readonly HospitalContext _context;

        public PatientService(HospitalContext context) 
        { 
            _context = context;
        }

        //Get Patient by first and last name
        //add where doctor id...so doctors can only pull up patients they have
        //public IEnumerable<Patient>? GetPatient(string firstName, string lastName) 
        //{
        //    //select * from Patients where...
        //    return _context.Patients.Where(patient => patient.FirstName == firstName 
        //    && patient.LastName == lastName);
        //}

        //public Patient? GetPatientById(string id)
        //{
        //    return _context.Patients.SingleOrDefault(patient => patient.Id == id);
        //}

        //public Patient? GetPatientEmail(string? email)
        //{
        //    //will throw exception if there is more than one of that email
        //    return _context.Patients.SingleOrDefault(patient => patient.Email == email);
        //}

        //public Patient? GetPatientSSN(string? ssn)
        //{
        //    return _context.Patients.SingleOrDefault(patient => patient.PatientSSN == ssn);
        //}

        ////Fetch patient by email, check associated password against the one entered
        //public Patient SignInPatient(string email, string password) 
        //{
        //    Patient? patient = GetPatientEmail(email); 

        //    if (patient == null) 
        //    {
        //        throw new Exception("PatientService.SignInPatient: Incorrect username or password");
        //    }

        //    //fetch password and compare to the password entered
        //   bool isMatch = BCrypt.Net.BCrypt.Verify(password, patient.PasswordHash);

        //    if (!isMatch)
        //    {
        //        throw new Exception("PatientService.SignInPatient: Incorrect username or password");
        //    }

        //    return patient;
        //}

        ////Add Patients to Database --add admin function
        //public Patient CreatePatient(Patient newPatient)
        //{
        //    //check if patient is unique (email and ssn must be unique)
        //    bool isUnique = GetPatientEmail(newPatient.Email) == null && 
        //        GetPatientSSN(newPatient.PatientSSN) == null ? true : false;

        //    if (!isUnique)
        //    {
        //        throw new Exception("PatientService.CreatePatient: This patient already exists in the system");
        //    }

        //    //add and save patient
        //    _context.Add(newPatient);

        //    //hash the password 
        //    string hashedPass = BCrypt.Net.BCrypt.HashPassword(newPatient.PasswordHash);
        //    newPatient.PasswordHash = hashedPass;

        //    //try catch here?
        //    _context.SaveChanges();
            
        //    return newPatient;
        //}
    }
}
