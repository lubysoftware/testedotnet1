using System;
using Flunt.Notifications;
using Flunt.Validations;
using LTS.Domain.Commands.Contracts;

namespace LTS.Domain.Commands.TimeSheet
{
    public class DeleteTimeSheetCommand : Notifiable, ICommand
    {
        public Guid Id { get; set; }

        public void Validate()
        {
            AddNotifications(
              new Contract()
                  .Requires()
                  .IsNotNull(Id, "Id", "Apontamento não encontrado")
          );
        }
    }
}
