using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TesteDotNet.ControleHoras.Aplicacao.DTO.DTO;
using TesteDotNet.ControleHoras.Aplicacao.Interfaces;
using TesteDotNet.ControleHoras.Dominio.Core.Interfaces.Servicos;
using TesteDotNet.ControleHoras.Dominio.Entidades;
using TesteDotNet.ControleHoras.DTO.Mapeamento.Map;

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

        public void Add(DesenvolvedorDTO dto)
        {
            var objDesenvolvedor = _mapper.Map<Desenvolvedor>(dto);
            _servico.Add(objDesenvolvedor);
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

        public Task<List<DesenvolvedorDTO>> GetAllAsync()
        {
            var objDevs = _servico.GetAllAsync();
            return _mapper.Map<Task<List<DesenvolvedorDTO>>>(objDevs);
        }

        public DesenvolvedorDTO GetById(int id)
        {
            var objDev = _servico.GetById(id);
            return _mapper.Map<DesenvolvedorDTO>(objDev);
        }

        public void Remove(DesenvolvedorDTO obj)
        {
            var objDev = _mapper.Map<Desenvolvedor>(obj);
            _servico.Remove(objDev);
        }

        public void Update(DesenvolvedorDTO obj)
        {
            var objDev = _mapper.Map<Desenvolvedor>(obj);
            _servico.Update(objDev);
        }
    }
}
