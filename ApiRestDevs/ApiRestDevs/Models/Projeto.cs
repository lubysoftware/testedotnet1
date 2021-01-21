using System.ComponentModel.DataAnnotations;

namespace ApiRestDevs.Models
{
    public class Projeto
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Este Campo é Obrigatório")]
        [MaxLength(100, ErrorMessage = "Tamanho do nome deve ser entre 10 e 100 carecteres")]
        [MinLength(10, ErrorMessage = "Tamanho do nome deve ser entre 10 e 100 carecteres")]
        public string Nome { get; set; }
    }
}
