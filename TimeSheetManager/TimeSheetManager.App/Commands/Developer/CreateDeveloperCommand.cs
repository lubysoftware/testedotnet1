using TimeSheetManager.App.Commands.Contracts;

namespace TimeSheetManager.App.Commands.DeveloperNS
{
    public class CreateDeveloperCommand : ICommand
    {
        public string Name { get; set; }

        public void Validate()
        {
        }
    }
}