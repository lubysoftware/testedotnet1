using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TesteDotNet.ControleHoras.Aplicacao.DTO.DTO;
using TesteDotNet.ControleHoras.Aplicacao.Interfaces;
using TesteDotNet.ControleHoras.Dominio.Interfaces.Servicos;
using TesteDotNet.ControleHoras.Dominio.Entidades;
using TesteDotNet.ControleHoras.DTO.Mapeamento.Map;
using Aplicacao.Principal;
using Microsoft.AspNetCore.JsonPatch;

namespace TesteDotNet.ControleHoras.Aplicacao.Servicos
{
    public class AppServicoDesenvolvedor : IAppServicoDesenvolvedor
    {
        private readonly IServicoDesenvolvedor _servico;
        private readonly IMapper _mapper;

        public AppServicoDesenvolvedor(IServicoDesenvolvedor servico, IMapper mapper)
        {
            _servico = servico;
            _mapper = mapper;
        }

        public ICadastroSalvarResultado Inserir(DesenvolvedorDTO dto)
        {            
            var objDesenvolvedor = _mapper.Map<Desenvolvedor>(dto);

            if(!objDesenvolvedor.Validar(false))            
                return new CadastroSalvarResultado(dto, objDesenvolvedor.Avisos, objDesenvolvedor.Erros);

            _servico.Add(objDesenvolvedor);

            var dtoRetorno = _mapper.Map<DesenvolvedorDTO>(objDesenvolvedor);

            return new CadastroSalvarResultado(dtoRetorno, objDesenvolvedor.Avisos, objDesenvolvedor.Erros);
        }

        public ICadastroSalvarResultado Update(DesenvolvedorDTO dto)
        {            
            var objDesenvolvedor = _mapper.Map<Desenvolvedor>(dto);

            if (!objDesenvolvedor.Validar(false))
                return new CadastroSalvarResultado(dto, objDesenvolvedor.Avisos, objDesenvolvedor.Erros);

            _servico.Update(objDesenvolvedor);

            var dtoRetorno = _mapper.Map<DesenvolvedorDTO>(objDesenvolvedor);

            return new CadastroSalvarResultado(dtoRetorno, objDesenvolvedor.Avisos, objDesenvolvedor.Erros);
        }

        public ICadastroSalvarResultado UpdatePatch(int id, JsonPatchDocument<DesenvolvedorDTO> dtoPatch)
        {
            //Objeto atual da base de dados.
            var devObj = _servico.GetById(id);
            //Converte para um DTO com os dados atuais.
            var devDto = _mapper.Map<DesenvolvedorDTO>(devObj);            
            //Aplica as alterações do dtoPatch no dto atual.
            dtoPatch.ApplyTo(devDto);
            //Faz um map da alterações do dto no objeto retornado pelo entity framework. Aqui não é gerada nova instância.
            devObj = _mapper.Map(devDto, devObj);
            //Valida antes do salvamento na base.
            if (!devObj.Validar(false))
                return new CadastroSalvarResultado(devDto, devObj.Avisos, devObj.Erros);
            //Efetiva o salvamento.
            _servico.Update(devObj);
            //Obtem um dto com os dados do retorno.
            var dtoRetorno = _mapper.Map<DesenvolvedorDTO>(devObj);
            //Retorna o sucesso ou falha da operação para ser tratado no controller.
            return new CadastroSalvarResultado(dtoRetorno, devObj.Avisos, devObj.Erros);
        }

        public ICadastroSalvarResultado Delete(int id)
        {
            var devObj = _servico.GetById(id);            
            var devDto = _mapper.Map<DesenvolvedorDTO>(devObj);
            
            if (!devObj.Validar(true))
                return new CadastroSalvarResultado(devDto, devObj.Avisos, devObj.Erros);

            _servico.Remove(devObj);

            var dtoRetorno = _mapper.Map<DesenvolvedorDTO>(devObj);
            return new CadastroSalvarResultado(dtoRetorno, devObj.Avisos, devObj.Erros);
        }

        public bool Exists(int id)
        {
            return _servico.Exists(id);
        }

        public void Dispose()
        {
            _servico.Dispose();
        }

        public IEnumerable<DesenvolvedorDTO> GetAll()
        {
            var objDevs = _servico.GetAll();
            return _mapper.Map<IEnumerable<DesenvolvedorDTO>>(objDevs);
        }

        public async Task<List<DesenvolvedorDTO>> GetAllAsync()
        {
            var objDevs = await _servico.GetAllAsync();
            return _mapper.Map<List<DesenvolvedorDTO>>(objDevs);
        }

        public DesenvolvedorDTO GetById(int id)
        {
            var objDev = _servico.GetById(id);
            return _mapper.Map<DesenvolvedorDTO>(objDev);
        }

        public Task<DesenvolvedorDTO> GetByIdAsync(int id)
        {
            var objDev = _servico.GetByIdAsync(id);
            return _mapper.Map<Task<DesenvolvedorDTO>>(objDev);
        }                
    }
}
