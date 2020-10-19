using System;
using TimeSheetManager.App.Commands.Contracts;

namespace TimeSheetManager.App.Commands.Project {
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