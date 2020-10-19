using TimeSheetManager.App.Commands.Contracts;

namespace TimeSheetManager.App.Commands.Developer {
    public class CreateDeveloperCommand : ICommand {
        public string Name { get; set; }

        public void Validate() {
        }
    }
}