using System;
using System.Threading.Tasks;
using TesteLuby.Domain.Attributes;
using TesteLuby.Domain.Commands;
using TesteLuby.Domain.Contracts;
using TesteLuby.Domain.Enums;
using TesteLuby.Domain.Models.Entities;
using TesteLuby.Domain.Models.Settings;

namespace TesteLuby.Domain.Handlers
{
    public class BusinessHourHandler: EntityHandler<BusinessHour>, IHandler
    {

        private readonly AuthenticatedUser _authUser;
        public BusinessHourHandler(IContext context, AuthenticatedUser authUser) : base(context)
        {
            _authUser = authUser;
        }

        public async Task<ICommandResult> GetRankingBusinessHourByDeveloper()
        {
            try
            {
                string sql = $"select " +
                    "top(5) " +
                    "sum(DATEDIFF(hour, developer.datetimestart, developer.datetimeend)) as businessweek, " +
                    "developer.username as developer" +
                    "from businesshour " +
                    "inner join developer on developer.id = businesshour.developerid " +
                    "where businesshour.datetimestart >= dateadd(day, -7, getdate()) and businesshour.datetimestart <= getdate() " +
                    "group by developerid " +
                    "order by businessweek desc";

                var retorno = await Repository.GetListBySql<Ranking>(sql);  
                ICommandResult resultadoServico = retorno == null 
                   ? new CommandResult((int)EStatus.NotFound, false, "Desenvolvedores não encontrados!", null) 
                   : new CommandResult((int)EStatus.Ok, true, "Desenvolvedores encontrado!", retorno);
                return resultadoServico;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Erro ao tentar consultar ranking. Erro: ", ex.Message);
            }
        }
    }
}