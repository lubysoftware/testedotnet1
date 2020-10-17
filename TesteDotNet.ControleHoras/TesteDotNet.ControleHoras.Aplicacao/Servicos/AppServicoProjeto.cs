using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TesteDotNet.ControleHoras.Aplicacao.DTO.DTO;
using TesteDotNet.ControleHoras.Aplicacao.Interfaces;
using TesteDotNet.ControleHoras.Dominio.Core.Interfaces.Servicos;
using TesteDotNet.ControleHoras.Dominio.Entidades;

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

        public ProjetoDTO Add(ProjetoDTO dto)
        {
            var obj = _mapper.Map<Projeto>(dto);
            _servico.Add(obj);
            return _mapper.Map<ProjetoDTO>(obj);
        }

        public void Dispose()
        {
            _servico.Dispose();
        }

        public IEnumerable<ProjetoDTO> GetAll()
        {
            var objs = _servico.GetAll();
            return _mapper.Map<IEnumerable<ProjetoDTO>>(objs);
        }

        public ProjetoDTO GetById(int id)
        {
            var obj = _servico.GetById(id);
            return _mapper.Map<ProjetoDTO>(obj);
        }

        public void Remove(ProjetoDTO dto)
        {
            var obj = _mapper.Map<Projeto>(dto);
            _servico.Remove(obj);
        }

        public void Update(ProjetoDTO dto)
        {
            var obj = _mapper.Map<Projeto>(dto);
            _servico.Update(obj);
        }
    }
}
