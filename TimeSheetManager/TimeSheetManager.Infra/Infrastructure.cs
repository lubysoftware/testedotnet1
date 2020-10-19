using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using TimeSheetManager.App.Handlers.DeveloperNS;
using TimeSheetManager.App.Handlers.ProjectNS;
using TimeSheetManager.Domain.Repositories;
using TimeSheetManager.Infra.Context;
using TimeSheetManager.Infra.Repositories;

namespace TimeSheetManager.Infra {
    public static class Infrastructure {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services) {
            services.AddScoped<IDeveloperRepository, DeveloperRepository>();
            setHandlers(services);

            return services;
        }

        private static void setHandlers(IServiceCollection services) {
            services.AddScoped<CreateDeveloperHandler>();
            services.AddScoped<DeleteDeveloperHandler>();
            services.AddScoped<UpdateDeveloperHandler>();
            services.AddScoped<CreateProjectHandler>();
            services.AddScoped<DeleteProjectHandler>();
            services.AddScoped<UpdateProjectHandler>();
        }
    }
}
