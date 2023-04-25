using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace HospitalManagement.Models
{
    //create a context for this
    //remeber to hook the context up in Program.cs
    public class ApplicationUserDoctor : IdentityUser
    {
        [Required]
        [MaxLength(50)]
        public string? FirstName { get; set; }

        [Required]
        [MaxLength(250)]
        public string? LastName { get; set; }

    }
}
