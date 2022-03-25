using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi1.Models
{
    public class Appointment
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Name cannot exceed 50 characters")]
        public string PetName { get; set; }

    }
}
