using TesteLuby.Domain.Attributes;
using TesteLuby.Domain.Commands;
using TesteLuby.Domain.Contracts;
using TesteLuby.Domain.Enums;
using TesteLuby.Domain.Models.Entities;
using TesteLuby.Domain.Models.Settings;
using System;
using System.Threading.Tasks;
using TesteLuby.Domain.CommandsParameters;

namespace TesteLuby.Domain.Handlers
{
    public class DeveloperHandler : EntityHandler<Developer>, IHandler
    {
        private readonly AuthenticatedUser _authUser;

        public DeveloperHandler(IContext context, AuthenticatedUser authUser) : base(context)
        {
            _authUser = authUser;
        }

        #region Get Methods

        public async Task<ICommandResult> GetByEmail(GetDeveloperByEmailCommand user)
        {
            try
            {
                string sql = $"Select * from developer where developer.email = '{user.Email}'";
                var retorno = await Repository.GetOneBySql(sql);
                ICommandResult resultadoServico = retorno == null
                   ? new CommandResult((int)EStatus.NotFound, false, "Usuário não encontrado !", null)
                   : new CommandResult((int)EStatus.Ok, true, "Usuário encontrado pelo e-mail!", retorno);
                return resultadoServico;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Erro ao tentar buscar um usuário pelo e-mail. Erro: ", ex.Message);
            }
        }
        #endregion

        #region Post Methods
        public async Task<ICommandResult> CreateDeveloper(CreateDeveloperCommand user)
        {
            try
            {
                var sqlExisteEmail = $"select * from developer where email = '{user.Email}'";
                var retornoExistenciaEmail = await Repository.GetOneBySql(sqlExisteEmail);
                var sqlExisteUsuario = $"select * from developer where username = '{user.UserName}'";
                var retornoExistenciaUsuario = await Repository.GetOneBySql(sqlExisteUsuario);
                if (retornoExistenciaEmail == null && retornoExistenciaUsuario == null)
                {
                    string sql = $"INSERT INTO developer " +
                        $"(username, email, password) " +
                        $"VALUES " +
                        $"('{user.UserName}', '{user.Email}', '{user.Password}') ";
                    var retorno = await Repository.InsertBySql(sql);
                    ICommandResult resultadoServico = retorno == false
                        ? new CommandResult((int)EStatus.InternalServerError, false, "Não foi possível adicionar um novo desenvolvedor!", null)
                        : new CommandResult((int)EStatus.Created, true, "O desenvolvedor foi adicionado com sucesso!", retorno);
                    return resultadoServico;
                }
                else
                {
                    return new CommandResult((int)EStatus.Forbidden, true, "Desenvolvedor já cadastrado !", null);
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.StartsWith("23505"))
                {
                    return new CommandResult((int)EStatus.Forbidden, true, "Desenvolvedor já cadastrado !", null);
                }
                else
                {
                    return new CommandResult((int)EStatus.InternalServerError, false, "Erro Interno ao tentar adicionar um desenvolvedor!", null);
                }
            }
        }


        public async Task<ICommandResult> CreateBusinessHourDeveloper(CreateBusinessHourCommand businessHour)
        {
            try
            {
                    string sql = $"INSERT INTO businesshour " +
                        $"(developerid, datetimestart, datetimeend) " +
                        $"VALUES " +
                        $"({businessHour.DeveloperId}, '{businessHour.DateTimeStart}', '{businessHour.DateTimeEnd}') ";
                    var retorno = await Repository.InsertBySql(sql);
                    ICommandResult resultadoServico = retorno == false
                        ? new CommandResult((int)EStatus.InternalServerError, false, "Não foi possível lançar uma hora para o desenvolvedor!", null)
                        : new CommandResult((int)EStatus.Created, true, "Hora lançada com sucesso!", retorno);
                    return resultadoServico;
            }
            catch (Exception ex)
            {
                return new CommandResult((int)EStatus.InternalServerError, false, "Erro Interno ao tentar lançar hora!"+ex.Message, null);
            }
        }

        #endregion

        #region Update Methods
        public async Task<ICommandResult> UpdateDeveloper(UpdateDeveloperCommand update)
        {
            try
            {
                return await UpdateDeveloperResource(update);
            }
            catch(Exception ex)
            {
                return new CommandResult((int)EStatus.InternalServerError, false,
                   $"Erro ao tentar atualizar o desenvolvedor."+ex.Message, null);
            }
        }

        internal async Task<ICommandResult> UpdateDeveloperResource(UpdateDeveloperCommand update)
        {
            try
            {
                string findUser = $"Select * from developer where guid = '{update.Guid}' ";
                var user = await Repository.GetOneBySql(findUser);
                var sqlExisteEmail = $"select * from developer where email = '{update.Email}' '";
                var retornoExistenciaEmail = await Repository.GetOneBySql(sqlExisteEmail);

                if (retornoExistenciaEmail == null)
                {
                    string sql =
                        $"Update developer set email = '{update.Email}', " +
                        $"username = '{update.UserName}' " +
                        $"where guid = '{update.Guid}' ";
                    var retorno = await Repository.UpdateBySql(sql);
                    ICommandResult resultadoServico = retorno == false
                       ? new CommandResult((int)EStatus.BadRequest, false, "Não foi possível atualizar o desenvolvedor! Desenvolvedor não encontrado.", null)
                       : new CommandResult((int)EStatus.Ok, true, "Desenvolvedor atualizado com sucesso!", retorno);
                    return resultadoServico;
                }
                else
                {
                    return new CommandResult((int)EStatus.BadRequest, false, "desenvolvedor ou email existentes.", null);
                }
            }
            catch
            {
                return new CommandResult((int)EStatus.InternalServerError, false,
                    $"Erro ao tentar atualizar o desenvolvedor.", null);
            }
        }
        #endregion

        #region delete method

        public async Task<ICommandResult> DeleteDeveloper(DeleteDeveloperCommand developer)
        {
            try
            {
                return await Delete(developer);
            }
            catch
            {
                return new CommandResult((int)EStatus.InternalServerError, false, "Erro ao tentar deletar um desenvolvedor!", null);
            }
        }

        internal async Task<ICommandResult> Delete(DeleteDeveloperCommand developer)
        {
            try
            {
                string sql = $"DELETE from developer where guid = '{developer.Guid}' ";
                var retorno = await Repository.DeleteBySql(sql);
                ICommandResult resultadoServico = retorno == false
                    ? new CommandResult((int)EStatus.BadRequest, false, "Não foi possível deletar um desenvolvedor!", null)
                    : new CommandResult((int)EStatus.Ok, true, "Desenvolvedor deletado com sucesso!", retorno);
                return resultadoServico;
            }
            catch
            {
                return new CommandResult((int)EStatus.InternalServerError, false,
                    "Erro ao tentar deletar desenvolvedor!", null);
            }
        }
        #endregion
    }
}
