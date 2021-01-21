using System.ComponentModel.DataAnnotations;

namespace ApiDevs.Models
{
    public class Desenvolvedor
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Este Campo é Obrigatório")]
        [MaxLength(60,ErrorMessage ="Tamanho do nome deve ser entre 3 e 60 carecteres")]
        [MinLength(3, ErrorMessage = "Tamanho do nome deve ser entre 3 e 60 carecteres")]
        public string Nome { get; set; }
    }
}
