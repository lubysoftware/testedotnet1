using TimeSheetManager.App.Commands.Contracts;

namespace TimeSheetManager.App.Commands.Project
{
    public class CreateProjectCommand : ICommand
    {
        public string Name { get; set; }

        public void Validate()
        {
        }
    }
}