using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Lançador_de_Horas_WebAPI.Models
{
    /// <summary>
    /// Projeto
    /// </summary>
    public class Projeto
    {
        /// Identificador
        [Key]
        public int Id { get; set; }

        /// Nome do projeto
        [Required]
        [DisplayName("Nome do projeto")]
        public string Nome { get; set; }

        /// Custo do projeto
        [Required]
        [DisplayName("Custo")]
        public double Custo { get; set; }

        /// Data de cadastro
        public readonly DateTime DataCriacao = DateTime.Now;

        /// Se o desenvolvedor está ativo ou não
        public bool Ativo { get; set; } = true;

        /// <summary>
        /// Construtor
        /// </summary>
        public Projeto()
        {
        }
    }
}