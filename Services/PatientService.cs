using HospitalManagement.Data;
using HospitalManagement.Models;
using Microsoft.EntityFrameworkCore;
using BCrypt.Net;

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
        public IEnumerable<Patient>? GetPatient(string firstName, string lastName) 
        {
            //select * from Patients where...
            return _context.Patients.Where(patient => patient.PatientFirstName == firstName 
            && patient.PatientLastName == lastName);
        }

        public Patient? GetPatientById(int id)
        {
            return _context.Patients.SingleOrDefault(patient => patient.PatientId == id);
        }

        public Patient? GetPatientEmail(string? email)
        {
            //will throw exception if there is more than one of that email
            return _context.Patients.SingleOrDefault(patient => patient.PatientEmail == email);
        }

        public Patient? GetPatientSSN(string? ssn)
        {
            return _context.Patients.SingleOrDefault(patient => patient.PatientSSN == ssn);
        }

        //Add Patients to Database --add admin function
        public Patient CreatePatient(Patient newPatient)
        {
            //check if patient is unique (email and ssn must be unique)
            bool isUnique = GetPatientEmail(newPatient.PatientEmail) == null && 
                GetPatientSSN(newPatient.PatientSSN) == null ? true : false;

            if (!isUnique)
            {
                throw new Exception("This patient already exists in the system");
            }

            //add and save patient
            _context.Add(newPatient);

            //hash the password 
            string hashedPass = BCrypt.Net.BCrypt.HashPassword(newPatient.PatientPassword);
            newPatient.PatientPassword = hashedPass;

            //try catch here?
            _context.SaveChanges();
            
            return newPatient;
        }
    }
}
