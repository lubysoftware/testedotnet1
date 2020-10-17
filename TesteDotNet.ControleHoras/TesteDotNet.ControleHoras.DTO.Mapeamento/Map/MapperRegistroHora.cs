using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TesteDotNet.ControleHoras.Aplicacao.DTO.DTO;
using TesteDotNet.ControleHoras.Dominio.Entidades;

namespace TesteDotNet.ControleHoras.DTO.Mapeamento.Map
{
    public class MapperRegistroHora : Profile
    {
        public MapperRegistroHora()
        {
            CreateMap<RegistroHora, RegistroHoraDTO>();
            CreateMap<RegistroHoraDTO, RegistroHora>();
        }
    }
}
