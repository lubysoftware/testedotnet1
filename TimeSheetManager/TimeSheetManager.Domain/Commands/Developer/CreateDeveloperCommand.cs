using TimeSheetManager.Domain.Commands.Contracts;

namespace TimeSheetManager.Domain.Commands.Developer {
    public class CreateDeveloperCommand : ICommand {
        public string Name { get; set; }

        public void Validate() {
        }
    }
}