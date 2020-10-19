using TimeSheetManager.Domain.Commands.Contracts;

namespace TimeSheetManager.Domain.Commands.Project {
    public class CreateProjectCommand : ICommand {
        public string Name { get; set; }

        public void Validate() {
        }
    }
}