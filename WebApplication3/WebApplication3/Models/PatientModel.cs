namespace WebApplication3.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class PatientModel : DbContext
    {
        public PatientModel()
            : base("name=PatientModel")
        {
        }

        public virtual DbSet<Patients1> Patients1 { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
