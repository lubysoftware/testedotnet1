using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TesteDotNet.ControleHoras.Aplicacao.DTO.DTO;
using TesteDotNet.ControleHoras.Aplicacao.Interfaces;
using TesteDotNet.ControleHoras.Dominio.Interfaces.Servicos;
using TesteDotNet.ControleHoras.Dominio.Entidades;
using Aplicacao.Principal;
using System.Threading.Tasks;
using Microsoft.AspNetCore.JsonPatch;
using System.Linq;

namespace TesteDotNet.ControleHoras.Aplicacao.Servicos
{
    public class AppServicoRegistroHora : IAppServicoRegistroHoras
    {
        private readonly IServicoRegistroHora _servico;
        private readonly IMapper _mapper;

        public AppServicoRegistroHora(IServicoRegistroHora servico, IMapper mapper)
        {
            _servico = servico;
            _mapper = mapper;
        }

        public async Task<ICadastroSalvarResultado> InserirAsync(RegistroHoraDTO dto)
        {
            var objRegistro = _mapper.Map<RegistroHora>(dto);

            if (dto.Id != 0)
                dto.Id = 0;

            if (!objRegistro.Validar(false))
                return new CadastroSalvarResultado(dto, objRegistro.Avisos, objRegistro.Erros);

            await _servico.AddAsync(objRegistro);

            var dtoRetorno = _mapper.Map<RegistroHoraDTO>(objRegistro);

            return new CadastroSalvarResultado(dtoRetorno, objRegistro.Avisos, objRegistro.Erros);
        }
        public async Task<ICadastroSalvarResultado> UpdateAsync(RegistroHoraDTO dto)
        {
            var objRegistro = _mapper.Map<RegistroHora>(dto);

            if (!objRegistro.Validar(false))
                return new CadastroSalvarResultado(dto, objRegistro.Avisos, objRegistro.Erros);

            await _servico.UpdateAsync(objRegistro);

            var dtoRetorno = _mapper.Map<RegistroHoraDTO>(objRegistro);

            return new CadastroSalvarResultado(dtoRetorno, objRegistro.Avisos, objRegistro.Erros);
        }
        public async Task<ICadastroSalvarResultado> UpdatePatchAsync(int id, JsonPatchDocument<RegistroHoraDTO> dtoPatch)
        {
            //Objeto atual da base de dados.
            var regObj = await _servico.GetByIdAsync(id);
            //Converte para um DTO com os dados atuais.
            var devDto = _mapper.Map<RegistroHoraDTO>(regObj);
            //Aplica as alterações do dtoPatch no dto atual.
            dtoPatch.ApplyTo(devDto);
            //Faz um map da alterações do dto no objeto retornado pelo entity framework. Aqui não é gerada nova instância.
            regObj = _mapper.Map(devDto, regObj);
            //Valida antes do salvamento na base.
            if (!regObj.Validar(false))
                return new CadastroSalvarResultado(devDto, regObj.Avisos, regObj.Erros);
            //Efetiva o salvamento.
            await _servico.UpdateAsync(regObj);
            //Obtem um dto com os dados do retorno.
            var dtoRetorno = _mapper.Map<RegistroHoraDTO>(regObj);
            //Retorna o sucesso ou falha da operação para ser tratado no controller.
            return new CadastroSalvarResultado(dtoRetorno, regObj.Avisos, regObj.Erros);
        }
        public async Task<ICadastroSalvarResultado> DeleteAsync(int id)
        {
            var devObj = await _servico.GetByIdAsync(id);
            var devDto = _mapper.Map<RegistroHoraDTO>(devObj);

            if (!devObj.Validar(true))
                return new CadastroSalvarResultado(devDto, devObj.Avisos, devObj.Erros);

            await _servico.RemoveAsync(devObj);

            var dtoRetorno = _mapper.Map<RegistroHoraDTO>(devObj);
            return new CadastroSalvarResultado(dtoRetorno, devObj.Avisos, devObj.Erros);
        }
        public async Task<bool> ExistsAsync(int id)
        {
            return await _servico.ExistsAsync(id);
        }
        public async Task<List<RegistroHoraDTO>> GetAllAsync()
        {
            var objRegs = await _servico.GetAllAsync();
            return _mapper.Map<List<RegistroHoraDTO>>(objRegs);
        }
        public async Task<RegistroHoraDTO> GetByIdAsync(int id)
        {
            var objDev = await _servico.GetByIdAsync(id);
            return _mapper.Map<RegistroHoraDTO>(objDev);
        }
        public async Task<List<RegistroHoraDTO>> GetRankingDesenvolvedoresSemanaComMaisHorasTrabalhadas(int numerDesenvolvedoresNoRanking)
        {
            //Obtém todos os registros de hora.
            var objDevs = await _servico.GetAllAsync();
            
            //Ordena por data de entrada.
            objDevs = objDevs.OrderBy(x => x.DataEntrada).ToList();         
            
            //Obtém o dia da semana do primeiro registro.            
            Ranking semanaInicio = new Ranking();
            semanaInicio.dataInicial = objDevs[0].DataEntrada;
            semanaInicio.dataFinal = semanaInicio.dataInicial.Value.AddDays(DayOfWeek.Saturday - semanaInicio.dataInicial.Value.DayOfWeek);
            
            //Inclui a semana inicial.
            List<Ranking> ranking = new List<Ranking>();
            ranking.Add(semanaInicio);

            //Ultima data de saída.
            objDevs = objDevs.OrderBy(x => x.DataSaida).ToList();
            var ultimaDataFinal = objDevs[objDevs.Count - 1].DataSaida;

            //Nùmero de semanas entre a primeira data inicial e a ultima data final.
            int numSemanas = Convert.ToInt32((ultimaDataFinal - semanaInicio.dataInicial).Value.TotalDays / 7);
            if ((ultimaDataFinal - semanaInicio.dataInicial).Value.TotalDays % 7 != 0)
                numSemanas += 1;
            
            //Agrupa por semana.
            DateTime dataFinalAnterior = semanaInicio.dataFinal.Value;
            for(int i = 0; i < numSemanas; i++)
            {
                if (i == 0)                                    
                    continue;
                                    
                Ranking semana = new Ranking();
                semana.dataInicial = dataFinalAnterior.AddDays(1);
                semana.dataFinal = semana.dataInicial.Value.AddDays(6);

                dataFinalAnterior = semana.dataFinal.Value;
            }

            //Para cada registro de hora soma na semana correspondente com o código do desenvolvedor.
            foreach (var reg in objDevs)
            {
                var r = ranking.First(x => x.dataInicial.Value.CompareTo(reg.DataEntrada) >= 0 &&
                                           x.dataFinal.Value.CompareTo(reg.DataSaida) <= 0);
                
                var dev = r.rankingDevs.FirstOrDefault(x => x.desenvolvedorId == reg.DesenvolvedorId);
            }

            return _mapper.Map<List<RegistroHoraDTO>>(objDevs);
        }

        public void Dispose()
        {
            _servico.Dispose();
        }
    }

    class Ranking
    {
        public DateTime? dataInicial;
        public DateTime? dataFinal;
        public List<RankingDev> rankingDevs = new List<RankingDev>();
    }
    class RankingDev
    {
        public int desenvolvedorId;
        public int numTotalHoras;
    }
}
