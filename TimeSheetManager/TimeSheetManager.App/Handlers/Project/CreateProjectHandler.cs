using System.Threading.Tasks;
using TimeSheetManager.App.Handlers.Contracts;
using TimeSheetManager.Domain.Commands;
using TimeSheetManager.Domain.Commands.Contracts;
using TimeSheetManager.Domain.Commands.Project;
using TimeSheetManager.Domain.Entities.Developer;
using TimeSheetManager.Domain.Repositories;

namespace TimeSheetManager.App.Handlers.ProjectNS {
    public class CreateProjectHandler : IHandler<CreateProjectCommand> {
        private readonly IDeveloperRepository _repository;

        public CreateProjectHandler(IDeveloperRepository repository) {
            _repository = repository;
        }

        public async Task<ICommandResult> Handle(CreateProjectCommand command){

            var dev = new Developer(command.Name);

             await _repository.Post(dev);

            return new GenericCommandResult(true, "Sucess", dev);

        }
        
    }
}