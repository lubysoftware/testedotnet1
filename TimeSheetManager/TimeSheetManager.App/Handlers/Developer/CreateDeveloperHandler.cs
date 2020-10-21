using System.Threading.Tasks;
using TimeSheetManager.App.Handlers.Contracts;
using TimeSheetManager.App.Commands;
using TimeSheetManager.App.Commands.Contracts;
using TimeSheetManager.App.Commands.DeveloperNS;
using TimeSheetManager.Domain.Entities.DeveloperNS;
using TimeSheetManager.Domain.Repositories;

namespace TimeSheetManager.App.Handlers.DeveloperNS
{
    public class CreateDeveloperHandler : IHandler<CreateDeveloperCommand>
    {
        private readonly IDeveloperRepository _repository;

        public CreateDeveloperHandler(IDeveloperRepository repository)
        {
            _repository = repository;
        }

        public async Task<ICommandResult> Handle(CreateDeveloperCommand command)
        {

            var dev = new Developer(command.Name);

            await _repository.Post(dev);

            return new GenericCommandResult(true, "Sucess", dev);

        }

    }
}