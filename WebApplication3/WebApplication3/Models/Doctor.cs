namespace WebApplication3.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Doctor
    {
        [Required]
        public string Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public int doctorId { get; set; }

        public int SuburbId { get; set; }

        [Required]
        public string Emailld { get; set; }

        [NotMapped]
        public string Fullname { get { return string.Concat("Dr. "+ FirstName + " " + LastName); } }
    }
}
