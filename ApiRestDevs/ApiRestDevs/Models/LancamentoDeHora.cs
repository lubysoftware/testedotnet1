using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ApiRestDevs.Models
{
    public class LancamentoDeHora
    {
        public LancamentoDeHora()
        {

        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Id do desenvolvedor é Obrigatório")]
        public int DesenvolvedorId { get; set; }

        [Required(ErrorMessage = "Id do projeto trabalhado é Obrigatório")]
        public int ProjetoTrabalhadoId { get; set; }

        [Required(ErrorMessage = "Data de Inicio é Obrigatória")]
        public DateTime DataDeInicio { get; set; }

        [Required(ErrorMessage = "Data Final é Obrigatória")]
        public DateTime DataFinal { get; set; }

        [Required(ErrorMessage = "Quantidade de Horas trabalhadas é Obrigatória")]        
        public double QtdHorasTrabalhadas  { get; set; }

        [JsonIgnore]
        public Projeto ProjetoTrabalhado { get; set; }
        [JsonIgnore]
        public Desenvolvedor Desenvolvedor { get; set; }

    }
}
