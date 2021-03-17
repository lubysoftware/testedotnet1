using Flunt.Notifications;
using LTS.Domain.Commands;
using LTS.Domain.Commands.Contracts;
using LTS.Domain.Commands.TimeSheet;
using LTS.Domain.Entities;
using LTS.Domain.Handlers.Contracts;
using LTS.Domain.Interfaces;
using System;
using System.Threading.Tasks;

namespace LTS.Domain.Handlers
{
    public class TimeSheetHandler :
        Notifiable,
        IHandler<CreateTimeSheetCommand>,
        IHandler<UpdateTimeSheetCommand>,
        IHandler<DeleteTimeSheetCommand>
    {
        private readonly ITimeSheetRepository _timeSheetRepository;
        public TimeSheetHandler(ITimeSheetRepository timeSheetRepository)
        {
            _timeSheetRepository = timeSheetRepository;
        }
        public async Task<ICommandResult> Handle(CreateTimeSheetCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Operação inválida", command.Notifications);

            var dateBegin = command.DateBegin.ToString("yyyy-MM-dd HH:mm:ss");
            var dateEnd = command.DateEnd.ToString("yyyy-MM-dd HH:mm:ss");

            var stamp = command.DateEnd.Subtract(command.DateBegin);

            var timeSheet = new TimeSheet(Convert.ToDateTime(dateBegin), Convert.ToDateTime(dateEnd), command.DeveloperId, command.ProjectId, stamp.TotalHours);

            await _timeSheetRepository.AddAsync(timeSheet);

            return new GenericCommandResult(true, "Apontamento criado com sucesso", timeSheet);

        }

        public async Task<ICommandResult> Handle(UpdateTimeSheetCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Operação inválida", command.Notifications);

            var timeShettDb = await _timeSheetRepository.GetByIdAsync(command.Id);

            if (timeShettDb == null)
                return new GenericCommandResult(false, "Apontamento não encontrado", command.Notifications);

            var dateBegin = command.DateBegin.ToString("yyyy-MM-dd HH:mm:ss");
            var dateEnd = command.DateEnd.ToString("yyyy-MM-dd HH:mm:ss");

            var stamp = command.DateEnd.Subtract(command.DateBegin);

            timeShettDb.DateBegin = Convert.ToDateTime(dateBegin);
            timeShettDb.DateEnd = Convert.ToDateTime(Convert.ToDateTime(dateEnd));
            timeShettDb.TotalHours = stamp.TotalHours;

            await _timeSheetRepository.UpdateAsync(timeShettDb);

            return new GenericCommandResult(true, "Apontamento alterado com sucesso", timeShettDb);

        }

        public async Task<ICommandResult> Handle(DeleteTimeSheetCommand command)
        {

            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Operação inválida", command.Notifications);

            var timeSheetDb = await _timeSheetRepository.GetByIdAsync(command.Id);

            if (timeSheetDb == null)
                return new GenericCommandResult(false, "Desenvolvedor não encontrado", command.Notifications);


            await _timeSheetRepository.DeleteAsync(command.Id);

            return new GenericCommandResult(true, "Desenvolvedor removido com sucesso", timeSheetDb);
        }
    }
}
