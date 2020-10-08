using Application.Interfaces;
using Application.Services;
using Data.Repositories;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Services;
using Infra.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.IoC
{
    public class DependencyInjector
    {
        public static void REgister(IServiceCollection svcCollection)
        {
            //Aplicação
            svcCollection.AddScoped(typeof(IApplicationBase<,>), typeof(ApplicationBase<,>));
            svcCollection.AddScoped<IPontoApplication, PontoApplication>();

            //Domínio
            svcCollection.AddScoped(typeof(IServiceBase<>), typeof(ServiceBase<>));
            svcCollection.AddScoped<IPontoService, PontoService>();

            //Repositorio
            svcCollection.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            svcCollection.AddScoped<IPontoRepository, PontoRepository>();
        }
    }
}
