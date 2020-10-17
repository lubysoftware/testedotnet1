using System;
using System.Collections.Generic;
using System.Text;

namespace TesteDotNet.ControleHoras.Aplicacao.DTO.DTO
{
    public class DesenvolvedorDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public int ProjetoId { get; set; }
    }
}
