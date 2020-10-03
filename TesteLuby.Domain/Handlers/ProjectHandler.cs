using System;
using System.Threading.Tasks;
using TesteLuby.Domain.Contracts;
using TesteLuby.Domain.Models.Entities;
using TesteLuby.Domain.Models.Settings;
using TesteLuby.Domain.Attributes;
using TesteLuby.Domain.Commands;
using TesteLuby.Domain.Enums;
using TesteLuby.Domain.CommandsParameters;

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


        #region Post Methods
        public async Task<ICommandResult> CreateProject(CreateProjectCommand project)
        {
            try
            {
               
                    string sql = $"INSERT INTO project " +
                        $"(projectname) " +
                        $"VALUES " +
                        $"('{project.ProjectName}') ";
                    var retorno = await Repository.InsertBySql(sql);
                    ICommandResult resultadoServico = retorno == false
                        ? new CommandResult((int)EStatus.InternalServerError, false, "Não foi possível adicionar um novo projeto!", null)
                        : new CommandResult((int)EStatus.Created, true, "O projeto foi adicionado com sucesso!", retorno);
                    return resultadoServico;
               
            }
            catch (Exception ex)
            {
                if (ex.Message.StartsWith("23505"))
                {
                    return new CommandResult((int)EStatus.Forbidden, true, "Projeto já cadastrado !", null);
                }
                else
                {
                    return new CommandResult((int)EStatus.InternalServerError, false, "Erro Interno ao tentar adicionar um projeto!", null);
                }
            }
        }

        #endregion

        #region Update Methods
        public async Task<ICommandResult> UpdateProject(UpdateProjectCommand project)
        {
            try
            {
                return await UpdateProjectResource(project);
            }
            catch
            {
                return new CommandResult((int)EStatus.InternalServerError, false,
                   $"Erro ao tentar atualizar o projeto.", null);
            }
        }

        internal async Task<ICommandResult> UpdateProjectResource(UpdateProjectCommand update)
        {
            try
            {
                string findUser = $"Select * from project where guid = '{update.Guid}' ";
                var user = await Repository.GetOneBySql(findUser);
                
                string sql = $"Update project set projectname = '{update.ProjectName}' where guid = '{update.Guid}' ";
                var retorno = await Repository.UpdateBySql(sql);
                ICommandResult resultadoServico = retorno == false
                       ? new CommandResult((int)EStatus.BadRequest, false, "Não foi possível atualizar o projeto! Projeto não encontrado.", null)
                       : new CommandResult((int)EStatus.Ok, true, "Projeto atualizado com sucesso!", retorno);
                return resultadoServico;
            }
            catch
            {
                return new CommandResult((int)EStatus.InternalServerError, false,
                    $"Erro ao tentar atualizar o projeto.", null);
            }
        }
        #endregion

        #region delete method

        public async Task<ICommandResult> DeleteProject(DeleteProjectCommand project)
        {
            try
            {
                return await Delete(project);
            }
            catch
            {
                return new CommandResult((int)EStatus.InternalServerError, false, "Erro ao tentar deletar um projeto!", null);
            }
        }

        internal async Task<ICommandResult> Delete(DeleteProjectCommand projeto)
        {
            try
            {
                string sql = $"DELETE from project where guid = '{projeto.Guid}' ";
                var retorno = await Repository.DeleteBySql(sql);
                ICommandResult resultadoServico = retorno == false
                    ? new CommandResult((int)EStatus.BadRequest, false, "Não foi possível deletar um projeto!", null)
                    : new CommandResult((int)EStatus.Ok, true, "Projeto deletado com sucesso!", retorno);
                return resultadoServico;
            }
            catch
            {
                return new CommandResult((int)EStatus.InternalServerError, false,
                    "Erro ao tentar deletar projeto!", null);
            }
        }
        #endregion
    }
}