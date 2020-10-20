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

namespace TesteDotNet.ControleHoras.Aplicacao.Servicos
{
    public class AppServicoProjeto : IAppServicoProjeto
    {
        private readonly IServicoProjeto _servico;
        private readonly IMapper _mapper;

        public AppServicoProjeto(IServicoProjeto servico, IMapper mapper)
        {
            _servico = servico;
            _mapper = mapper;
        }
                
        public async Task<ICadastroSalvarResultado> InserirAsync(ProjetoDTO dto)
        {
            var objProjeto = _mapper.Map<Projeto>(dto);

            if (!objProjeto.Validar(false))
                return new CadastroSalvarResultado(dto, objProjeto.Avisos, objProjeto.Erros);

            await _servico.AddAsync(objProjeto);

            var dtoRetorno = _mapper.Map<ProjetoDTO>(objProjeto);

            return new CadastroSalvarResultado(dtoRetorno, objProjeto.Avisos, objProjeto.Erros);
        }
        public async Task<ICadastroSalvarResultado> UpdateAsync(ProjetoDTO dto)
        {
            var objProjeto = _mapper.Map<Projeto>(dto);

            if (!objProjeto.Validar(false))
                return new CadastroSalvarResultado(dto, objProjeto.Avisos, objProjeto.Erros);

            await _servico.UpdateAsync(objProjeto);

            var dtoRetorno = _mapper.Map<ProjetoDTO>(objProjeto);

            return new CadastroSalvarResultado(dtoRetorno, objProjeto.Avisos, objProjeto.Erros);
        }
        public async Task<ICadastroSalvarResultado> UpdatePatchAsync(int id, JsonPatchDocument<ProjetoDTO> dtoPatch)
        {
            //Objeto atual da base de dados.
            var projObj = await _servico.GetByIdAsync(id);
            //Converte para um DTO com os dados atuais.
            var devDto = _mapper.Map<ProjetoDTO>(projObj);
            //Aplica as alterações do dtoPatch no dto atual.
            dtoPatch.ApplyTo(devDto);
            //Faz um map da alterações do dto no objeto retornado pelo entity framework. Aqui não é gerada nova instância.
            projObj = _mapper.Map(devDto, projObj);
            //Valida antes do salvamento na base.
            if (!projObj.Validar(false))
                return new CadastroSalvarResultado(devDto, projObj.Avisos, projObj.Erros);
            //Efetiva o salvamento.
            await _servico.UpdateAsync(projObj);
            //Obtem um dto com os dados do retorno.
            var dtoRetorno = _mapper.Map<ProjetoDTO>(projObj);
            //Retorna o sucesso ou falha da operação para ser tratado no controller.
            return new CadastroSalvarResultado(dtoRetorno, projObj.Avisos, projObj.Erros);
        }
        public async Task<ICadastroSalvarResultado> DeleteAsync(int id)
        {
            var devObj = await _servico.GetByIdAsync(id);
            var devDto = _mapper.Map<ProjetoDTO>(devObj);

            if (!devObj.Validar(true))
                return new CadastroSalvarResultado(devDto, devObj.Avisos, devObj.Erros);

            await _servico.RemoveAsync(devObj);

            var dtoRetorno = _mapper.Map<ProjetoDTO>(devObj);
            return new CadastroSalvarResultado(dtoRetorno, devObj.Avisos, devObj.Erros);
        }
        public async Task<bool> ExistsAsync(int id)
        {
            return await _servico.ExistsAsync(id);
        }
        public async Task<List<ProjetoDTO>> GetAllAsync()
        {
            var objDevs = await _servico.GetAllAsync();
            return _mapper.Map<List<ProjetoDTO>>(objDevs);
        }
        public async Task<ProjetoDTO> GetByIdAsync(int id)
        {
            var objDev = await _servico.GetByIdAsync(id);
            return _mapper.Map<ProjetoDTO>(objDev);
        }

        public void Dispose()
        {
            _servico.Dispose();
        }
    }
}
