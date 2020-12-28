using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using TesteLuby.Data.Repositories;
using TesteLuby.Repository.Appointments;
using TesteLuby.Repository.Developers;
using TesteLuby.Repository.Projects;

namespace TesteLuby.Shared.InjectionDependency
{
    public static class InjectionDependencyRepositories
    {
        public static void AddRepositories(this IServiceCollection serviceDescriptors)
        {
            serviceDescriptors.AddScoped<IProjectRepository, ProjectRepository>();
            serviceDescriptors.AddScoped<IDeveloperRepository, DevelopersRepository>();
            serviceDescriptors.AddScoped<IAppointmentRepository, AppointmentRepository>();
        }
    }
}
