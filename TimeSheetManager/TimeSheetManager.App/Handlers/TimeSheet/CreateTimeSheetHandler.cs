using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TimeSheetManager.App.Handlers.Contracts;
using TimeSheetManager.App.Commands;
using TimeSheetManager.App.Commands.Contracts;
using TimeSheetManager.App.Commands.TimeSheet;
using TimeSheetManager.Domain.Entities.TimeSheetNS;
using TimeSheetManager.Domain.Repositories;

namespace TimeSheetManager.App.Handlers.TimeSheetNS {
    public class CreateTimeSheetHandler : IHandler<CreateTimeSheetCommand> {
        private readonly ITimeSheetRepository _repository;

        public CreateTimeSheetHandler(ITimeSheetRepository repository) {
            _repository = repository;
        }

        public async Task<ICommandResult> Handle(CreateTimeSheetCommand command) {
            var timesheet = new TimeSheet(command.DevId, command.Entry, command.Exit);
            await _repository.Create(timesheet);
            return new GenericCommandResult(true, "Sucess", timesheet);
        }
    }
}
