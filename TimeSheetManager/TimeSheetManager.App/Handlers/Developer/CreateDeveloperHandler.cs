using System.Threading.Tasks;
using AutoMapper;
using TimeSheetManager.App.Handlers.Contracts;
using TimeSheetManager.Domain.Commands;
using TimeSheetManager.Domain.Commands.Contracts;
using TimeSheetManager.Domain.Commands.Developer;
using TimeSheetManager.Domain.Entities.Developer;
using TimeSheetManager.Domain.Repositories;

namespace TimeSheetManager.App.Handlers.DeveloperNS {
    public class CreateDeveloperHandler : IHandler<CreateDeveloperCommand> {
        private readonly IDeveloperRepository _repository;

        public CreateDeveloperHandler(IDeveloperRepository repository) {
            _repository = repository;
        }

        public async Task<ICommandResult> Handle(CreateDeveloperCommand command){

            var dev = new Developer(command.Name);

             await _repository.Post(dev);

            return new GenericCommandResult(true, "Sucess", dev);

        }
        
    }
}