using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Lançador_de_Horas_WebAPI.Models
{
    /// <summary>
    /// Usuário desenvolvedor
    /// </summary>
    public class Desenvolvedor
    {
        ///Identificador
        [Key]
        public int Id { get; set; }

        /// Nome do desenvolvedor
        [Required]
        [DisplayName("Nome")]
        public string Nome { get; set; }

        /// Sobrenome do desenvolvedor
        [Required]
        [DisplayName("Sobrenome")]
        public string Sobrenome { get; set; }

        /// CPF do desenvolvedor
        [Required]
        [DisplayName("CPF")]
        public string CPF { get; set; }

        /// Data de cadastro
        public readonly DateTime DataCriacao = DateTime.Now;

        /// Se o desenvolvedor está ativo ou não
        public bool Ativo { get; set; } = true;

        /// <summary>
        /// Construtor
        /// </summary>
        public Desenvolvedor()
        {
        }
    }
}