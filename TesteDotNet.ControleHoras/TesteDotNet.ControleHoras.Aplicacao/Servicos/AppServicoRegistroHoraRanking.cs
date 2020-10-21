using Aplicacao.DTO.DTO;
using Aplicacao.Principal.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteDotNet.ControleHoras.Dominio.Interfaces.Servicos;

namespace Aplicacao.Principal.Servicos
{
    public class AppServicoRegistroHoraRanking : IAppServicoRegistroHorasRanking
    {        
        private readonly IServicoRegistroHora _servicoRegistro;
        
        public AppServicoRegistroHoraRanking(IServicoRegistroHora servicoRegistro)
        {            
            _servicoRegistro = servicoRegistro;            
        }

        public async Task<RegistroHoraRankingDTO> GetSemanaComMaisHorasTrabalhadas(int numeroDesenvolvedoresNoRanking)
        {
            //Inicializa.
            var rankingSemanaMaisHorasDTO = new RegistroHoraRankingDTO();
            
            //Obtém todos os registros de hora.
            var registroHoras = await _servicoRegistro.GetAllAsync();
            
            //Ordena por data de entrada.
            registroHoras = registroHoras.OrderBy(x => x.DataHoraEntrada).ToList();
            
            //Para cada registro de hora soma na semana correspondente com o código do desenvolvedor.
            Ranking ranking = new Ranking();
            foreach (var reg in registroHoras)
            {
                ranking.AddRegistro(reg.DesenvolvedorId, reg.DataHoraEntrada.Value, reg.DataHoraSaida.Value);
            }
            
            //Ordena o ranking por número total de horas.
            RankingSemana rankingSemana = ranking.rankingSemanas.OrderByDescending(x => x.TotalHoras).First();
            IOrderedEnumerable<RankingDev> rankingSemanaDevs = rankingSemana.RankingDevs.OrderByDescending(x => x.numTotalHoras);

            //Repassa para o DTO.
            rankingSemanaMaisHorasDTO.DataInicioSemana = rankingSemana.DataInicioSemana.Value;
            rankingSemanaMaisHorasDTO.DataFinalSemana = rankingSemana.DataFinalSemana.Value;
            rankingSemanaMaisHorasDTO.TotalHorasTrabalhadas = rankingSemana.TotalHoras;

            foreach(var dev in rankingSemanaDevs)
            {
                if (rankingSemanaMaisHorasDTO.DesenvolvedoresComMaisHoras.Count() == numeroDesenvolvedoresNoRanking)
                    break;

                rankingSemanaMaisHorasDTO.DesenvolvedoresComMaisHoras.Add(dev.desenvolvedorId, dev.numTotalHoras);
            }
                
            return rankingSemanaMaisHorasDTO;
        }
    }

    class Ranking
    {
        public List<RankingSemana> rankingSemanas = new List<RankingSemana>();
        public void AddRegistro(int desenvolvedorId, DateTime dataHoraEntrada, DateTime dataHoraSaida)
        {            
            //Data da entrada em formato curto.
            DateTime dataEntrada = new DateTime(dataHoraEntrada.Year, dataHoraEntrada.Month, dataHoraEntrada.Day);

            //Verifica se a data de entrada já pertence a uma semana de trabalho 'mapeada'. Se não, cria a semana.
            var rankingSemana = rankingSemanas.FirstOrDefault(x => dataEntrada.CompareTo(x.DataInicioSemana) >= 0 &&
                                                                   dataEntrada.CompareTo(x.DataFinalSemana) <= 0);
            if (rankingSemana == null)
            {
                rankingSemana = new RankingSemana();
                rankingSemana.DataInicioSemana = dataEntrada.AddDays((int)dataEntrada.DayOfWeek * -1);
                rankingSemana.DataFinalSemana = rankingSemana.DataInicioSemana.Value.AddDays(6);
                
                rankingSemanas.Add(rankingSemana);                                
            }

            //Lança o desenvolvedor e suas horas no ranking.
            double totalHoras = (dataHoraSaida - dataHoraEntrada).TotalHours;
            rankingSemana.AddHorasDesenvolvedor(desenvolvedorId, totalHoras);
        }
    }
    class RankingSemana
    {
        public double TotalHoras = 0;
        public DateTime? DataInicioSemana;
        public DateTime? DataFinalSemana;

        public List<RankingDev> RankingDevs = new List<RankingDev>();

        public void AddHorasDesenvolvedor(int desenvolvedorId, double numHoras)
        {
            //Tenta obter o desenvolvedor do ranking da semana.
            var rankingDev = RankingDevs.FirstOrDefault(x => x.desenvolvedorId == desenvolvedorId);
            //Se não encontrar cria o objeto e adiciona.
            if (rankingDev == null)
            {
                rankingDev = new RankingDev
                {
                    desenvolvedorId = desenvolvedorId
                };

                RankingDevs.Add(rankingDev);
            }
            //Incrementa as horas vinculadas ao desenvolvedor na semana.
            rankingDev.numTotalHoras += numHoras;
            //Somatório da semana.
            TotalHoras += numHoras;
        }
    }
    class RankingDev
    {
        public int desenvolvedorId;
        public double numTotalHoras;
    }
}
