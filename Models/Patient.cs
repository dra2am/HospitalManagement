using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace HospitalManagement.Models
{
    [Index(nameof(PatientSSN), IsUnique=true)]
    public class Patient 
    {
        public int PatientId { get; set; }

        public ApplicationUser? User { get; set; }

        [Required]
        public DateTime PatientDOB { get; set; }

        public Gender PatientGender { get; set; }

        [Required]
        public string? PatientSSN { get; set; }

        public ICollection<Doctor>? Doctors { get; set; }

        public ICollection<Appointment>? Appointments { get; set; }

        public enum Gender
        {
            Female,
            Male,
            NonBinary,
        } 
    }
}
