using Aplicacao.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace TesteDotNet.ControleHoras.Aplicacao.DTO.DTO
{
    public class ProjetoDTO : IEntidadeDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
    }
}
