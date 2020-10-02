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
                string sql = $"select top(3) DATEDIFF(hour, developer.openfriday, customers.closefriday) as DiferencaDias from customers order by  DiferencaDias desc Select sum() from developers order by";
                var retorno = await Repository.GetOneBySql(sql);
                ICommandResult resultadoServico = retorno == null
                   ? new CommandResult((int)EStatus.NotFound, false, "Desenvolvedores não encontrados!", null)
                   : new CommandResult((int)EStatus.Ok, true, "Desenvolvedores encontrado!", retorno);
                return resultadoServico;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Erro ao tentar buscar um usuário pelo e-mail. Erro: ", ex.Message);
            }
        }
    }
}