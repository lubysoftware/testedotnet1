using Application.DTO;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{
    public class MappingEntities : Profile
    {
        public MappingEntities()
        {
            CreateMap<Ponto, PontoDTO>().ReverseMap();
        }
    }
}
