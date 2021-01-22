using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ApiRestDevs.Models
{
    public class Projeto
    {
        public Projeto()
        {

        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Este Campo é Obrigatório")]
        [MaxLength(100, ErrorMessage = "Tamanho do nome deve ser entre 10 e 100 carecteres")]
        [MinLength(10, ErrorMessage = "Tamanho do nome deve ser entre 10 e 100 carecteres")]
        public string Nome { get; set; }

        [JsonIgnore]
        public ICollection<LancamentoDeHora> LancamentoDeHoras { get; set; }

    }
}
