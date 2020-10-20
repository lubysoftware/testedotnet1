using System;
using System.Collections.Generic;
using System.Text;
using TimeSheetManager.App.Commands.Contracts;

namespace TimeSheetManager.App.Commands.TimeSheet {
    public class CreateTimeSheetCommand : ICommand {
        public CreateTimeSheetCommand() {
        }

        public CreateTimeSheetCommand(Guid devId, DateTime entry, DateTime exit) {
            DevId = devId;
            Entry = entry;
            Exit = exit;
        }
        public int Id { get; }
        public Guid DevId { get; }
        public DateTime Entry { get; }
        public DateTime Exit { get; }
        public void Validate() {
            //validacao
        }
    }
}
