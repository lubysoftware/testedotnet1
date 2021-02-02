using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace apiLuby.Models
{
    public class Developer
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage ="O campo {0} é obrigatório.")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres.", MinimumLength = 2)]
        public String Name { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public DateTime RegistrationDate { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public String Password { get; set; }

        public bool Active { get; set; }

        public ICollection<Project> Projects { get; set; }

        public Guid IdProject { get; set; }

        public ICollection<Appointment> Appointments { get; set; }

        public Guid IdAppointment { get; set; }
    }
}
