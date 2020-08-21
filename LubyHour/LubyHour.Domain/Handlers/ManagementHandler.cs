using LubyHour.Domain.Commands.Input.Management;
using LubyHour.Domain.Commands.output;
using LubyHour.Domain.Entities;
using LubyHour.Domain.Interfaces;
using System;
using System.Threading.Tasks;

namespace LubyHour.Domain.Handlers
{
    public class ManagementHandler :
        IHandler<GetManagementByIdCommand>,
        IHandler<PostManagementCommand>,
        IHandler<UpdateManagementCommand>,
        IHandler<DeleteManagementCommand>
    {
        private readonly IRepository _repository;
        public ManagementHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<ICommandResult> GetAllManagement()
        {
            try
            {
                var management = await _repository.GetAll();

                ICommandResult result = management != null
                    ? new CommandResult(true, "Lançamentos encontrados com sucesso!", management)
                    : new CommandResult(true, "Nenhum lançamento encontrado!", null);
                return result;
            }
            catch 
            {
                return new CommandResult(false,"Erro interno ao tentar buscar os lançamentos!", null);
            }
        }

        public async Task<ICommandResult> Handle(GetManagementByIdCommand command)
        {
            try
            {
                command.Validate();
                if (command.Invalid)
                    return new CommandResult(false,"Dados inválidos!", command.Notifications);

               var management = await _repository.GetById(command.Id);

                ICommandResult result = management != null
                  ? new CommandResult(true, "Lançamento encontrado com sucesso!", management)
                  : new CommandResult(true, "Lançamento não encontrado!", null);
                return result;
            }
            catch
            {
                return new CommandResult(false, "Erro interno ao tentar buscar o lançamento!", null);
            }
        }

        public async Task<ICommandResult> Handle(PostManagementCommand command)
        {
            try
            {
                command.Validate();
                if (command.Invalid)
                    return new CommandResult(false,"Dados inválidos!", command.Notifications);
               
                var management = new Management(command.Developer,command.StartTime,command.EndTime);
                _repository.Create(management);

                return new CommandResult(true, "Lançamento criado com sucesso!", null);
            }
            catch
            {
                return new CommandResult(false, "Erro interno ao tentar criar o lançamento!", null);
            }
        }

        public async Task<ICommandResult> Handle(UpdateManagementCommand command)
        {
            try
            {
                command.Validate();
                if (command.Invalid)
                    return new CommandResult(false,"Dados inválidos!", command.Notifications);

                var getManagement = await _repository.GetById(command.Id);
                var management = new Management
                {
                    Id = getManagement.Id,
                    Developer = command.Developer,
                    StartTime = command.StartTime,
                    EndTime = command.EndTime
                };

                _repository.Update(management);

                return new CommandResult(true, "Lançamento atualizado com sucesso!", null);
            }
            catch
            {
                return new CommandResult(false, "Erro interno ao tentar atualizar o lançamento!", null);
            }
        }

        public async Task<ICommandResult> Handle(DeleteManagementCommand command)
        {
            try
            {
                command.Validate();
                if (command.Invalid)
                    return new CommandResult(false,"Dados inválidos!", command.Notifications);
               
                var management = new Management
                {
                    Id = command.Id,
                    Developer = command.Developer,
                    StartTime = command.StartTime,
                    EndTime = command.EndTime
                };

                _repository.Delete(management);

                return new CommandResult(true, "Lançamento removido com sucesso!", null);
            }
            catch
            {
                return new CommandResult(false, "Erro interno ao tentar remover o lançamento!", null);
            }
        }
    }
}
