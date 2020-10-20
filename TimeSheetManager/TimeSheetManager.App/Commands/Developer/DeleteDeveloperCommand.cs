using System;
using TimeSheetManager.App.Commands.Contracts;

namespace TimeSheetManager.App.Commands.DeveloperNS
{
    public class DeleteDeveloperCommand : ICommand
    {

        public DeleteDeveloperCommand(Guid _Id)
        {
            Id = _Id;
        }
        public Guid Id { get; }
        public void Validate()
        {
            //validacao
        }
    }
}