namespace WebApplication3.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DoctModel : DbContext
    {
        public DoctModel()
            : base("name=DoctModel")
        {
        }

        public virtual DbSet<Doctor> Doctors { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
