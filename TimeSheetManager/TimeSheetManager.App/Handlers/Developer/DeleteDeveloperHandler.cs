using System.Threading.Tasks;
using TimeSheetManager.App.Handlers.Contracts;
using TimeSheetManager.Domain.Commands;
using TimeSheetManager.Domain.Commands.Contracts;
using TimeSheetManager.Domain.Commands.Developer;
using TimeSheetManager.Domain.Repositories;

namespace TimeSheetManager.App.Handlers.DeveloperNS {
    public class DeleteDeveloperHandler : IHandler<DeleteDeveloperCommand>{
        private readonly IDeveloperRepository _repository;

        public DeleteDeveloperHandler(IDeveloperRepository repository){
            _repository = repository;
        }
        public async Task<ICommandResult> Handle(DeleteDeveloperCommand command){
            

            await _repository.Delete(command.Id);
            
            return new GenericCommandResult(true, "Sucess", "");
        }
    }
}