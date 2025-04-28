using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalManagement.Models
{
    public class Appointment
    {
        public int AppointmentId { get; set; }
        [Required]
        [ForeignKey("PatientId")]
        public Patient? Patient { get; set; }
        public int PatientId { get; set; }
        [Required]
        [ForeignKey("DoctorId")] 
        public Doctor? Doctor { get; set; }
        public int DoctorId { get; set; }
        [Required] public DateTime AppointmentTime { get; set; }
        [Required] public string? AppointmentDesc { get; set; }  


    }
}
