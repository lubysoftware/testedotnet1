using TesteLuby.Domain.Commands;
using TesteLuby.Domain.Contracts;
using TesteLuby.Domain.Enums;
using TesteLuby.Domain.Models.Settings;
using System;
using System.Threading.Tasks;
using TesteLuby.Domain.Attributes;
using TesteLuby.Domain.Models.Entities;

namespace TesteLuby.Domain.Handlers
{
    public class ProjectDeveloperHandler : EntityHandler<ProjectDeveloper>, IHandler
    {
        private readonly AuthenticatedUser _authUser;

        public ProjectDeveloperHandler(IContext context, AuthenticatedUser authUser) : base(context)
        {
            _authUser = authUser;
        }

        public async Task<ICommandResult> Get()
        {
            try
            {
                string sql = $"Select * from projectdeveloper";
                var retorno = await Repository.GetOneBySql(sql);
                ICommandResult resultadoServico = retorno == null
                   ? new CommandResult((int)EStatus.NotFound, false, "Registro não encontrado !", null)
                   : new CommandResult((int)EStatus.Ok, true, "Registro encontrado!", retorno);
                return resultadoServico;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Erro ao tentar buscar registro. Erro: ", ex.Message);
            }
        }
    }
}