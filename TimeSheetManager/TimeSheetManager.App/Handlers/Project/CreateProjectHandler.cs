using System.Threading.Tasks;
using TimeSheetManager.App.Handlers.Contracts;
using TimeSheetManager.App.Commands;
using TimeSheetManager.App.Commands.Contracts;
using TimeSheetManager.App.Commands.Project;
using TimeSheetManager.Domain.Entities.DeveloperNS;
using TimeSheetManager.Domain.Repositories;

namespace TimeSheetManager.App.Handlers.ProjectNS
{
    public class CreateProjectHandler : IHandler<CreateProjectCommand>
    {
        private readonly IDeveloperRepository _repository;

        public CreateProjectHandler(IDeveloperRepository repository)
        {
            _repository = repository;
        }

        public async Task<ICommandResult> Handle(CreateProjectCommand command)
        {

            var dev = new Developer(command.Name);

            await _repository.Post(dev);

            return new GenericCommandResult(true, "Sucess", dev);

        }

    }
}