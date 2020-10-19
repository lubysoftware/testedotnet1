using System;
using TimeSheetManager.Domain.Commands.Contracts;

namespace TimeSheetManager.Domain.Commands.Developer {
        public class UpdateDeveloperCommand : ICommand {

        public UpdateDeveloperCommand(Guid Id, string Name) {
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