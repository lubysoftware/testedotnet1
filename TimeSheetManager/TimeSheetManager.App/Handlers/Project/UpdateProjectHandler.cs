using System.Threading.Tasks;
using TimeSheetManager.App.Handlers.Contracts;
using TimeSheetManager.App.Commands;
using TimeSheetManager.App.Commands.Contracts;
using TimeSheetManager.App.Commands.Project;
using TimeSheetManager.Domain.Repositories;

namespace TimeSheetManager.App.Handlers.ProjectNS
{
    public class UpdateProjectHandler : IHandler<UpdateProjectCommand>
    {
        private readonly IProjectRepository _repository;

        public UpdateProjectHandler(IProjectRepository repository)
        {
            _repository = repository;
        }

        public async Task<ICommandResult> Handle(UpdateProjectCommand command)
        {

            var project = await _repository.Get(command.Id);
            project.ChangeName(command.Name);

            await _repository.Update(project);

            return new GenericCommandResult(true, "Sucess Update", project);
        }

    }
}