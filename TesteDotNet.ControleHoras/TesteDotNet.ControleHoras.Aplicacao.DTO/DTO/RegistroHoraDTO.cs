using Aplicacao.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace TesteDotNet.ControleHoras.Aplicacao.DTO.DTO
{
    public class RegistroHoraDTO : IEntidadeDTO
    {
        public int Id { get; set; }
        public int DesenvolvedorId { get; set; }        
        public DateTime? DataHoraEntrada { get; set; }        
        public DateTime? DataHoraSaida { get; set; }        
    }
}
