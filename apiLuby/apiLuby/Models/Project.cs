using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace apiLuby.Models
{
    public class Project
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public String Name { get; set; }

        public int EstimatedHours { get; set; }

        public ICollection<Appointment> Appointment { get; set; }

        public int IdAppointment { get; set; }
    }
}
