namespace WebApplication3.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class geo : DbContext
    {
        public geo()
            : base("name=geo")
        {
        }

        public virtual DbSet<postcodes_geo> postcodes_geo { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<postcodes_geo>()
                .Property(e => e.latitude)
                .HasPrecision(6, 3);

            modelBuilder.Entity<postcodes_geo>()
                .Property(e => e.longitude)
                .HasPrecision(6, 3);
        }
    }
}
