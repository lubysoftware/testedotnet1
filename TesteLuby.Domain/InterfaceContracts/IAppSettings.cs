using TesteLuby.Domain.Enums;
using TesteLuby.Domain.Models.Settings;

namespace TesteLuby.Domain.Contracts
{
    public interface IAppSettings
    {
        string GetConnectionString();
        string GetStringConnection();
        EAppEnvironment GetAppEnvironment();
        ConnectionBd GetConnectionBd();
        ConnectionStringSettings GetConnectionStringSettings();
        JwtSetting GetJwtSettings();
    }
}
