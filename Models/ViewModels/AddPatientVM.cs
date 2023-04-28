using System.ComponentModel.DataAnnotations;

namespace HospitalManagement.Models.ViewModels
{
    public class AddPatientVM
    {
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        [Required]
       public string? Email { get; set; }

        [Required]
        public string? Password { get; set; }

        
        //[Required]
        //public string? PatientSSN { get; set; }
    }
}
