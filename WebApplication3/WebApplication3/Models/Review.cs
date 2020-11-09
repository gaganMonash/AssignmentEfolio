namespace WebApplication3.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Review
    {
        public int Id { get; set; }

        public int Rating { get; set; }

        [Required]
        public string PatientId { get; set; }

        [Required]
        public string DoctorId { get; set; }
    }
}
