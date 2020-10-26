using Hours.Domain.Interfaces.Repositories.Base;
using Hours.Infra.Context;
using Hours.Infra.Repository.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Hours.API.Extensions
{
    public class ConfigureRepository
    {       
        public static void ConfigureDepedenciesRepository(IServiceCollection services)
        {            
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));

            services.AddDbContext<ContextDB>(
          op => op.UseSqlServer("Server=.\\SQLEXPRESS; Database=HoursRonaldoBruno; Integrated Security=SSPI;MultipleActiveResultSets=True"));
            
        }
    }
}
