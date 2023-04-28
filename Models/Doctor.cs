using System.ComponentModel.DataAnnotations;

namespace HospitalManagement.Models
{
    public class Doctor 
    {
        public int DoctorId { get; set; }
        public ApplicationUser? User { get; set; }

        [Required]
        [MaxLength(50)]
        public string? DoctorTitle { get; set; }
        public ICollection<Patient>? Patients { get; set; }
        public ICollection<Appointment>? Appointments { get; set; }
    }
}
