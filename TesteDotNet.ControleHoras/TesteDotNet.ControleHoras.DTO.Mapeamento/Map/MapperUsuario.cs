using Aplicacao.DTO.DTO;
using AutoMapper;
using Dominio.Principal.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using TesteDotNet.ControleHoras.Aplicacao.DTO.DTO;
using TesteDotNet.ControleHoras.Dominio.Entidades;

namespace Infra.DTO.Mapeamento.Map
{
    public class MapperUsuario : Profile
    {
        public MapperUsuario()
        {
            CreateMap<Usuario, UsuarioDTO>();
            CreateMap<UsuarioDTO, Usuario>();
        }
    }
}