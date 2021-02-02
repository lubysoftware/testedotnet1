using System;
using System.ComponentModel.DataAnnotations;

namespace apiLuby.Models
{
    public class Appointment
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public DateTime StartedAt { get; set; }

        public DateTime FinishedAt { get; set; }

        public Developer Developer { get; set; }

        public int IdDeveloper { get; set; }

        public Project Project { get; set; }

        public int IdProject { get; set; }
    }
}
