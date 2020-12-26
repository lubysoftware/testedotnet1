using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using test.data.Context;

namespace test.application.Middlewares.DependencyInjection
{
    public class ConfigureDataBase
    {
        public static void ConfigureDependenciesDataBase(IServiceCollection serviceCollection)
        {
            serviceCollection.AddDbContext<MyContext>(
                options => options.UseSqlServer("Server=.\\SQLEXPRESS;Initial Catalog=LubyTest;Trusted_Connection=True;MultipleActiveResultSets=true")
            );
        }
    }
}
