using System.Threading.Tasks;
using TimeSheetManager.App.Handlers.Contracts;
using TimeSheetManager.App.Commands;
using TimeSheetManager.App.Commands.Contracts;
using TimeSheetManager.App.Commands.Project;
using TimeSheetManager.Domain.Entities.DeveloperNS;
using TimeSheetManager.Domain.Repositories;
using TimeSheetManager.Domain.Entities.Project;

namespace TimeSheetManager.App.Handlers.ProjectNS
{
    public class CreateProjectHandler : IHandler<CreateProjectCommand>
    {
        private readonly IProjectRepository _repository;

        public CreateProjectHandler(IProjectRepository repository)
        {
            _repository = repository;
        }

        public async Task<ICommandResult> Handle(CreateProjectCommand command)
        {

            var project = new Project(command.Name);

            await _repository.Post(project);

            return new GenericCommandResult(true, "Sucess", project);

        }

    }
}