using System.ComponentModel.DataAnnotations;

namespace Luby.API.ViewModel
{
    public class DesenvolvedorViewModel
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório!")]
        [StringLength(255, ErrorMessage = "O campo Nome deve ter no máximo 255 caracteres!")]
        public string Nome { get; set; }
    }
}