using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace apiLuby.Models
{
    public class Project
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public String Name { get; set; }

        public int EstimatedHours { get; set; }

        public ICollection<Appointment> Appointment { get; set; }

        public Guid IdAppointment { get; set; }
    }
}
