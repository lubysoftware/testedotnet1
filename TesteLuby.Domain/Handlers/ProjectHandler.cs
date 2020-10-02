using System;
using System.Threading.Tasks;
using TesteLuby.Domain.Contracts;
using TesteLuby.Domain.Models.Entities;
using TesteLuby.Domain.Models.Settings;
using TesteLuby.Domain.Attributes;
using TesteLuby.Domain.Commands;
using TesteLuby.Domain.Enums;

namespace TesteLuby.Domain.Handlers
{
    public class ProjectHandler : EntityHandler<Project>, IHandler
    {
        private readonly AuthenticatedUser _authUser;

        public ProjectHandler(IContext context, AuthenticatedUser authUser) : base(context)
        {
            _authUser = authUser;
        }

        public async Task<ICommandResult> Get()
        {
            try
            {
                string sql = $"Select * from projects";
                var retorno = await Repository.GetListBySql<Project>(sql);
                ICommandResult resultadoServico = retorno == null
                   ? new CommandResult((int)EStatus.NotFound, false, "Projetos não encontrados!", null)
                   : new CommandResult((int)EStatus.Ok, true, "Projetos encontrados!", retorno);
                return resultadoServico;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Erro ao tentar buscar os projectos. Erro: ", ex.Message);
            }
        }
    }
}