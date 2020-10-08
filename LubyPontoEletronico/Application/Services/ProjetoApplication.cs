using Application.DTO;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services
{
    public class ProjetoApplication : ApplicationBase<Projeto, ProjetoDTO>, IProjetoApplication
    {
        public ProjetoApplication(IMapper map, IProjetoService service) : base(map, service)
        {
        }
    }
}
