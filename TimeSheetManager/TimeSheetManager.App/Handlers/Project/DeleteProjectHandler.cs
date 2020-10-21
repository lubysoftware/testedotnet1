using System.Threading.Tasks;
using TimeSheetManager.App.Handlers.Contracts;
using TimeSheetManager.App.Commands;
using TimeSheetManager.App.Commands.Contracts;
using TimeSheetManager.App.Commands.Project;
using TimeSheetManager.Domain.Repositories;

namespace TimeSheetManager.App.Handlers.ProjectNS
{
    public class DeleteProjectHandler : IHandler<DeleteProjectCommand>
    {
        private readonly IProjectRepository _repository;

        public DeleteProjectHandler(IProjectRepository repository)
        {
            _repository = repository;
        }
        public async Task<ICommandResult> Handle(DeleteProjectCommand command)
        {
            await _repository.Delete(command.Id);

            return new GenericCommandResult(true, "Sucess", $"{command.Id} deleted.");
        }
    }
}