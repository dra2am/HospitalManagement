using System.ComponentModel.DataAnnotations;

namespace HospitalManagement.Models.ViewModels
{
    public class LoginPatientVM
    {

       [Required]
       public string? UserName { get; set; }

       [Required]
       public string? Password { get; set; }

    }
}
