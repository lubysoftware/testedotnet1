using Flunt.Notifications;
using Flunt.Validations;
using LTS.Domain.Commands.Contracts;
using System;

namespace LTS.Domain.Commands.Developer
{
    public class DeleteDeveloperCommand : Notifiable, ICommand
    {
        public Guid Id { get; set; }

        public void Validate()
        {
            AddNotifications(
              new Contract()
                  .Requires()
                  .IsNotNull(Id, "Id", "Desenvolvedor não encontrado")
          );
        }
    }
}

