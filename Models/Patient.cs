using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace HospitalManagement.Models
{
    [Index(nameof(PatientSSN), nameof(PatientEmail), IsUnique=true)]
    public class Patient
    {
        public int PatientId { get; set; }

        [Required]
        [MaxLength(50)]
        public string? PatientFirstName { get; set; }

        [Required]
        [MaxLength(250)]
        public string? PatientLastName { get; set; }

        [Required]
        public DateTime PatientDOB { get; set; }

        public Gender PatientGender { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(250)]
        public string? PatientEmail { get; set; }

        public string? PatientPhone { get; set; }

        [Required]
        public string? PatientSSN { get; set; }

        [Required]
        public string? PatientPassword { get; set; }

        public ICollection<Doctor>? Doctors { get; set; }

        public ICollection<Appointment>? Appointments { get; set; }

        public enum Gender
        {
            Female,
            Male,
            Other
        } 
    }
}
