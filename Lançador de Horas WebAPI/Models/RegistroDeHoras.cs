using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lançador_de_Horas_WebAPI.Models
{
    /// <summary>
    /// Registro de horas lançadas
    /// </summary>
    public class RegistroDeHoras
    {
        /// Identificador
        [Key]
        public int Id { get; set; }

        /// Data de início para registro
        [Required]
        [DisplayName("Data início")]
        public DateTime DataInicio { get; set; }

        /// Data final para registro
        [Required]
        [DisplayName("Data final")]
        public DateTime DataFim { get; set; }

        /// Total de horas trabalhadas no período
        [Required]
        [DisplayName("Total de horas")]
        [DataType(DataType.Time, ErrorMessage = "Hora em formato inválido")]
        public TimeSpan TotalHoras { get; set; }

        /// Id do desenvolvedor
        [Required]
        [DisplayName("Desenvolvedor")]
        public int DesenvolvedorId { get; set; }

        /// Id do projeto
        [Required]
        [DisplayName("Projeto")]
        public int ProjetoId { get; set; }

        /// atributo referente a foreignKey do desenvolvedor
        [ForeignKey("DesenvolvedorId")]
        public Desenvolvedor Desenvolvedor { get; set; }

        /// atributo referente a foreignKey do projeto
        [ForeignKey("ProjetoId")]
        public Projeto Projeto { get; set; }

        /// Data de cadastro
        public readonly DateTime DataCriacao = DateTime.Now;

        /// <summary>
        /// Construtor
        /// </summary>
        public RegistroDeHoras()
        {
        }
    }
}