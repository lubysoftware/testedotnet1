using System.Threading.Tasks;
using TimeSheetManager.App.Handlers.Contracts;
using TimeSheetManager.Domain.Commands;
using TimeSheetManager.Domain.Commands.Contracts;
using TimeSheetManager.Domain.Commands.Developer;
using TimeSheetManager.Domain.Repositories;

namespace TimeSheetManager.App.Handlers.DeveloperNS {
    public class UpdateDeveloperHandler : IHandler<UpdateDeveloperCommand> {
        private readonly IDeveloperRepository _repository;

        public UpdateDeveloperHandler(IDeveloperRepository repository) {
            _repository = repository;
        }

        public async Task<ICommandResult> Handle(UpdateDeveloperCommand command) {

            var dev = await _repository.Get(command.Id);
            dev.ChangeName(command.Name);

            await _repository.Update(dev);

            return new GenericCommandResult(true, "Sucess Update", dev);
        }

    }
}