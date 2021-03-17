using System;
using Flunt.Notifications;
using Flunt.Validations;
using LTS.Domain.Commands.Contracts;

namespace LTS.Domain.Commands.Project
{
    public class UpdateProjectCommand : Notifiable, ICommand
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public void Validate()
        {
            AddNotifications(
              new Contract()
                  .Requires()
                  .IsNotNull(Id, "Id", "Projeto não encontrado")
                  .IsNotNullOrEmpty(Name, "Name", "Por favor informe o nome do projeto.")
          );
        }
    }
}
