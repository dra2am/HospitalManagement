//import models
using HospitalManagement.Models;
using Microsoft.EntityFrameworkCore;


namespace HospitalManagement.Data
{
    //Add context to Program.cs
    public class HospitalContext : DbContext
    {
        public HospitalContext( DbContextOptions<HospitalContext> options) : base (options) { }
        //create tables in db based off Models
        public DbSet<Patient> Patients => Set<Patient>();
        public DbSet<Doctor> Doctors => Set<Doctor>();
        public DbSet<Address> Addresss => Set<Address>();
        public DbSet<Appointment> Appointments => Set<Appointment>();

    }
}
