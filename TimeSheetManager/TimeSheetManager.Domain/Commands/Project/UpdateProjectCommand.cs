using System;
using TimeSheetManager.Domain.Commands.Contracts;

namespace TimeSheetManager.Domain.Commands.Project {
        public class UpdateProjectCommand : ICommand {

        public UpdateProjectCommand(Guid Id, string Name) {
            this.Id = Id;
            this.Name = Name;
        }
        public Guid Id { get; }
        public string Name { get; }
        public void Validate(){
            //validacao
        }
    }
}