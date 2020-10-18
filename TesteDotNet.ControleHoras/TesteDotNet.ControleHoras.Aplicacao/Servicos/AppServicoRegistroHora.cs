using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TesteDotNet.ControleHoras.Aplicacao.DTO.DTO;
using TesteDotNet.ControleHoras.Aplicacao.Interfaces;
using TesteDotNet.ControleHoras.Dominio.Interfaces.Servicos;
using TesteDotNet.ControleHoras.Dominio.Entidades;

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

        public RegistroHoraDTO Add(RegistroHoraDTO dto)
        {
            var obj = _mapper.Map<RegistroHora>(dto);
            _servico.Add(obj);
            return _mapper.Map<RegistroHoraDTO>(obj);
        }

        public void Dispose()
        {
            _servico.Dispose();
        }

        public IEnumerable<RegistroHoraDTO> GetAll()
        {
            var objs = _servico.GetAll();
            return _mapper.Map<IEnumerable<RegistroHoraDTO>>(objs);
        }

        public RegistroHoraDTO GetById(int id)
        {
            var obj = _servico.GetById(id);
            return _mapper.Map<RegistroHoraDTO>(obj);
        }

        public void Remove(RegistroHoraDTO dto)
        {
            var obj = _mapper.Map<RegistroHora>(dto);
            _servico.Remove(obj);
        }

        public void Update(RegistroHoraDTO dto)
        {
            var obj = _mapper.Map<RegistroHora>(dto);
            _servico.Update(obj);
        }
    }
}
