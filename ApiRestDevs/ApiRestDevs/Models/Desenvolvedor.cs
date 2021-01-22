using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ApiRestDevs.Models
{
    public class Desenvolvedor
    {
        public Desenvolvedor()
        {

        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Este Campo é Obrigatório")]
        [MaxLength(60, ErrorMessage = "Tamanho do nome deve ser entre 3 e 60 carecteres")]
        [MinLength(3, ErrorMessage = "Tamanho do nome deve ser entre 3 e 60 carecteres")]
        public string Nome { get; set; }

        [JsonIgnore]
        public ICollection<LancamentoDeHora> LancamentoDeHoras { get; set; }
    }
}