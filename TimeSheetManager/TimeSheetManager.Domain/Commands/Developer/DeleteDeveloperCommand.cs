using System;
using TimeSheetManager.Domain.Commands.Contracts;

namespace TimeSheetManager.Domain.Commands.Developer {
        public class DeleteDeveloperCommand : ICommand {

        public DeleteDeveloperCommand(Guid _Id) {
            Id = _Id;
        }
        public Guid Id { get; }
        public void Validate(){
            //validacao
        }
    }
}