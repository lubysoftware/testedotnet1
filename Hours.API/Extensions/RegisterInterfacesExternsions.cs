using Hours.Application.Application;
using Hours.Application.Interface;
using Hours.Domain.Entities;
using Hours.Domain.Interfaces.Repositories;
using Hours.Domain.Interfaces.Repositories.Base;
using Hours.Domain.Interfaces.Repositories.Users;
using Hours.Domain.Interfaces.Services.Hours;
using Hours.Domain.Interfaces.Services.User;
using Hours.Domain.Services.Hours;
using Hours.Domain.Services.User;
using Hours.Infra.Repository.Base;
using Hours.Infra.Repository.Commands;
using Hours.Infra.Repository.Queries;
using Microsoft.Extensions.DependencyInjection;
using User.Application.Application;
using User.Application.Interface;
using User.Infra.Repository.Queries;

namespace Hours.Extensions
{
    public static class RegisterInterfacesExternsions
    {
        public static void RegisterInterface(this IServiceCollection services)
        {
            services.AddTransient<IHoursApplication, HoursApplication>();
            services.AddTransient<IHoursService, HoursServices>();
            services.AddTransient<IHoursCommands, HoursCommands>();
            services.AddTransient<IHoursQueries, HoursQueries>();

            services.AddTransient<IUserApplication, UserApplication>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IUserCommands, UserCommands>();
            services.AddTransient<IUserQueries, UserQueries>();

            services.AddTransient<IRepository<BaseEntity>, BaseRepository<BaseEntity>>();
        }
    }
}
