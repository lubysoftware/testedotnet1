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
                string sql = $"Select * from users where users.email = '{user.Email}'";
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

        #region Posts Methods
        public async Task<ICommandResult> CreateUser(CreateDeveloperCommand user)
        {
            try
            {
                var sqlExisteEmail = $"select * from users where email = '{user.Email}'";
                var retornoExistenciaEmail = await Repository.GetOneBySql(sqlExisteEmail);
                var sqlExisteUsuario = $"select * from users where username = '{user.UserName}'";
                var retornoExistenciaUsuario = await Repository.GetOneBySql(sqlExisteUsuario);
                if (retornoExistenciaEmail == null && retornoExistenciaUsuario == null)
                {
                    string sql = $"INSERT INTO users " +
                        $"(username, email, password,phonenumber, lastacess) " +
                        $"VALUES " +
                        $"('{user.UserName}', '{user.Email}', '{user.Password}', '{user.PhoneNumber}', {DateTime.Now.Day}) ";
                    var retorno = await Repository.InsertBySql(sql);
                    ICommandResult resultadoServico = retorno == false
                        ? new CommandResult((int)EStatus.InternalServerError, false, "Não foi possível adicionar um novo usuário !", null)
                        : new CommandResult((int)EStatus.Created, true, "O usuário foi adicionado com sucesso !", retorno);
                    return resultadoServico;
                }
                else
                {
                    return new CommandResult((int)EStatus.Forbidden, true, "Usuário ou email já cadastrado !", null);
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.StartsWith("23505"))
                {
                    return new CommandResult((int)EStatus.Forbidden, true, "Usuário já cadastrado !", null);
                }
                else
                {
                    return new CommandResult((int)EStatus.InternalServerError, false, "Erro Interno ao tentar adicionar um usuário. !", null);
                }
            }
        }


        public async Task<ICommandResult> CreateBusinessHour(CreateBusinessHourCommand businessHour)
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
                return new CommandResult((int)EStatus.InternalServerError, false, "Erro Interno ao tentar lançar hora!", null);
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
            catch
            {
                return new CommandResult((int)EStatus.InternalServerError, false,
                   $"Erro ao tentar atualizar o usuário.", null);
            }
        }

        internal async Task<ICommandResult> UpdateDeveloperResource(UpdateDeveloperCommand update)
        {
            try
            {
                string findUser = $"Select * from users where guid = '{update.Guid}' ";
                var user = await Repository.GetOneBySql(findUser);
                var sqlExisteEmail = $"select * from users where email = '{update.Email}' and users.guid != '{update.Guid}'";
                var retornoExistenciaEmail = await Repository.GetOneBySql(sqlExisteEmail);
                var sqlExisteUsuario = $"select * from users where username = '{update.UserName}' and users.guid != '{update.Guid}'";
                var retornoExistenciaUsuario = await Repository.GetOneBySql(sqlExisteUsuario);

                if (retornoExistenciaEmail == null)
                {
                    string sql =
                        $"Update users set email = '{update.Email}', " +
                        $"username = '{update.UserName}', firstname = '{update.FirstName}', " +
                        $"lastname = '{update.LastName}', phonenumber = '{update.PhoneNumber}', rating = {update.Rating}  " +
                        $"where guid = '{update.Guid}' ";
                    var retorno = await Repository.UpdateBySql(sql);
                    ICommandResult resultadoServico = retorno == false
                       ? new CommandResult((int)EStatus.BadRequest, false, "Não foi possível atualizar o usuário! Usuário não encontrado.", null)
                       : new CommandResult((int)EStatus.Ok, true, "Usuário atualizado com sucesso!", retorno);
                    return resultadoServico;
                }
                else
                {
                    return new CommandResult((int)EStatus.BadRequest, false, "usuário ou email existentes.", null);
                }
            }
            catch
            {
                return new CommandResult((int)EStatus.InternalServerError, false,
                    $"Erro ao tentar atualizar o usuário.", null);
            }
        }
        #endregion

    }
}
