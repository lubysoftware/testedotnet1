using System;
using TimeSheetManager.Domain.Commands.Contracts;

namespace TimeSheetManager.Domain.Commands.Project {
        public class DeleteProjectCommand : ICommand {

        public DeleteProjectCommand(Guid _Id) {
            Id = _Id;
        }
        public Guid Id { get; }
        public void Validate(){
            //validacao
        }
    }
}