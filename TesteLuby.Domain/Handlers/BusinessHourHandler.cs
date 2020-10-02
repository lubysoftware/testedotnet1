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
                return null;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Erro ao tentar buscar um usuário pelo e-mail. Erro: ", ex.Message);
            }
        }
    }
}