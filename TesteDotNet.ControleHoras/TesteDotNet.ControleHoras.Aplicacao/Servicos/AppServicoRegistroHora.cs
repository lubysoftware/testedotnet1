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
        
        public void Dispose()
        {
            _servico.Dispose();
        }
    }
}
