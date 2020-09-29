using AutoMapper;
using Flunt.Notifications;
using LTS.Domain.Commands;
using LTS.Domain.Commands.Contracts;
using LTS.Domain.Commands.Developer;
using LTS.Domain.Entities;
using LTS.Domain.Handlers.Contracts;
using LTS.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LTS.Domain.Handlers
{
    public class DeveloperHandler :
        Notifiable,
        IHandler<CreateDeveloperCommand>,
        IHandler<UpdateDeveloperCommand>,
        IHandler<DeleteDeveloperCommand>
    {
        private readonly IDeveloperRepository _developerRepository;
        private readonly IMapper _mapper;
        public DeveloperHandler(IDeveloperRepository developerRepository, IMapper mapper)
        {
            _developerRepository = developerRepository;
            _mapper = mapper;
        }
        public async Task<ICommandResult> Handle(CreateDeveloperCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Operação inválida", command.Notifications);


            var developer = _mapper.Map<Developer>(command);

            await _developerRepository.AddAsync(developer);

            return new GenericCommandResult(true, "Desenvolvedor criado com sucesso", developer);

        }

        public async Task<ICommandResult> Handle(UpdateDeveloperCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Operação inválida", command.Notifications);

            var developerDb = await _developerRepository.GetByIdAsync(command.Id);

            if (developerDb == null)
                return new GenericCommandResult(false, "Desenvolvedor não encontrado", command.Notifications);


            _mapper.Map(command, developerDb);

            await _developerRepository.UpdateAsync(developerDb);

            return new GenericCommandResult(true, "Desenvolvedor alterado com sucesso", developerDb);

        }

        public async Task<ICommandResult> Handle(DeleteDeveloperCommand command)
        {

            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Operação inválida", command.Notifications);

            var developerDb = await _developerRepository.GetByIdAsync(command.Id);

            if (developerDb == null)
                return new GenericCommandResult(false, "Desenvolvedor não encontrado", command.Notifications);


            await _developerRepository.DeleteAsync(command.Id);

            return new GenericCommandResult(true, "Desenvolvedor removido com sucesso", developerDb);
        }
    }
}
