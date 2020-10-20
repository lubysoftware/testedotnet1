using System;
using TimeSheetManager.App.Commands.Contracts;

namespace TimeSheetManager.App.Commands.DeveloperNS {
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