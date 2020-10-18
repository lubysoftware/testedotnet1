using System.Data;

namespace TimeManager.Application.Common.Interfaces
{
    public interface ISqlConnectionFactory
    {
        IDbConnection GetOpenConnection();
    }
}