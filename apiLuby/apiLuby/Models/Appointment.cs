using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace apiLuby.Models
{
    public class Appointment
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public DateTime StartedAt { get; set; }

        public DateTime FinishedAt { get; set; }

        public Developer Developer { get; set; }

        public Guid IdDeveloper { get; set; }

        public Project Project { get; set; }

        public Guid IdProject { get; set; }
    }
}
