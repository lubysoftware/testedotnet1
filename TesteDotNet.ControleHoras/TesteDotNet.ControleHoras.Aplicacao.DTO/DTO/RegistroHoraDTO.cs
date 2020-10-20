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
        public DateTime? DataEntrada { get; set; }
        public TimeSpan? HoraEntrada { get; set; }
        public DateTime? DataSaida { get; set; }
        public TimeSpan? HoraSaida { get; set; }
    }
}
