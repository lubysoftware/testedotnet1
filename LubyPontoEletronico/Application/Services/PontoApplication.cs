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
    public class PontoApplication : ApplicationBase<Ponto, PontoDTO>, IPontoApplication
    {
        public PontoApplication(IMapper map, IServiceBase<Ponto> service) : base(map, service)
        {
        }
    }
}
