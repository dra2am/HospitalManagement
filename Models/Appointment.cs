using System.ComponentModel.DataAnnotations;

namespace HospitalManagement.Models
{
    public class Appointment
    {
        public int AppointmentId { get; set; }
        [Required] 
        public Patient? Patient { get; set; }
        [Required]
        public Doctor? Doctor { get; set; }
        [Required]
        public DateTime AppointmentTime { get; set; }
        //should i make the id a composite key of patient id and date (+ doc?)?
    }
}
