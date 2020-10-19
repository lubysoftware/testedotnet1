using System.Threading.Tasks;
using TimeSheetManager.App.Handlers.Contracts;
using TimeSheetManager.Domain.Commands;
using TimeSheetManager.Domain.Commands.Contracts;
using TimeSheetManager.Domain.Commands.Project;
using TimeSheetManager.Domain.Repositories;

namespace TimeSheetManager.App.Handlers.ProjectNS {
    public class UpdateProjectHandler : IHandler<UpdateProjectCommand> {
        private readonly IDeveloperRepository _repository;

        public UpdateProjectHandler(IDeveloperRepository repository) {
            _repository = repository;
        }

        public async Task<ICommandResult> Handle(UpdateProjectCommand command) {

            var project = await _repository.Get(command.Id);
            project.ChangeName(command.Name);

            await _repository.Update(project);

            return new GenericCommandResult(true, "Sucess Update", project);
        }

    }
}