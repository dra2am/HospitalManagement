using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace HospitalManagement.Models
{
    //remove-migration
    //create new IdentityUser class for doctors
    //create new context for doctors
    //this may create a new schema...thats probably fine
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
