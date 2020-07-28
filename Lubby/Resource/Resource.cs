using Microsoft.Extensions.Configuration;
using System.IO;

namespace Lubby.Domain
{
    public class Resource
    {
        private static string Path => System.IO.Path.GetFullPath(Directory.GetCurrentDirectory());
        private static IConfigurationRoot Configuration => new ConfigurationBuilder().SetBasePath(Path).AddJsonFile("appsettings.json").Build();
        public static string ConnectionString => Configuration.GetConnectionString("DefaultConfiguration");
    }
}
