using System;
using Flunt.Notifications;
using Flunt.Validations;
using LTS.Domain.Commands.Contracts;

namespace LTS.Domain.Commands.Project
{
    public class DeleteProjectCommand : Notifiable, ICommand
    {
        public Guid Id { get; set; }
        public void Validate()
        {
            AddNotifications(
              new Contract()
                  .Requires()
                  .IsNotNull(Id, "Id", "Projeto não encontrado")
          );
        }
    }
}
