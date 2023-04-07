using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalManagement.Models
{
    public class Address
    {
        public int AddressID { get; set; }  

        [ForeignKey("PatientId")]
        public Patient? Patient { get; set; }
        [Required] public string? Street { get; set; }
        [Required] public string? City { get; set; }
        [Required] public string? State { get; set; }
        [Required] public string? PostalCode { get; set; }
    }
}
