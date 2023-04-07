using System.ComponentModel.DataAnnotations;

namespace HospitalManagement.Models
{
    public class Doctor
    {
        public int DoctorId { get; set; }

        [Required]
        [MaxLength(50)]
        public string? DoctorFirstName { get; set; }

        [Required]
        [MaxLength(250)] 
        public string? DoctorLastName { get; set;}

        [Required]
        [MaxLength(50)]
        public string? DoctorTitle { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(250)] 
        public string? DoctorEmail { get; set;}

        [Required]
        public string? DoctorPassword { get; set;}

        public ICollection<Patient>? Patients { get; set; }
        public ICollection<Appointment>? Appointments { get; set; }
    }
}
