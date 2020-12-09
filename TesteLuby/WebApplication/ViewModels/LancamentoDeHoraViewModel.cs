using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication.ViewModels
{
    public class LancamentoDeHoraViewModel
    {
        [Key] public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public DateTime HoraInicio { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public DateTime HoraFim { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public Guid DesenvolvedorId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public Guid ProjetoId { get; set; }
    }
}