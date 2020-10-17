using AutoMapper;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using TesteDotNet.ControleHoras.Aplicacao.DTO.DTO;
using TesteDotNet.ControleHoras.Dominio.Entidades;

namespace TesteDotNet.ControleHoras.DTO.Mapeamento.Map
{
    public class MapperDesenvolvedor : Profile
    {
        public MapperDesenvolvedor()
        {
            CreateMap<Desenvolvedor, DesenvolvedorDTO>();
            CreateMap<DesenvolvedorDTO, Desenvolvedor>();
        }
    }
}
