using Flunt.Notifications;
using Flunt.Validations;
using LTS.Domain.Commands.Contracts;
using System;

namespace LTS.Domain.Commands.Developer
{
    public class UpdateDeveloperCommand : Notifiable, ICommand
    {
        public Guid Id { get; set; }
        public int Age { get; set; }
        public string LinkedinURL { get; set; }

        public void Validate()
        {
            AddNotifications(
              new Contract()
                  .Requires()
                  .IsNotNull(Id, "Id", "Desenvolvedor não encontrado")
                  .IsGreaterThan(Age, 0, "Age", "Idade deve ser maior que 0")
          );
        }
    }
}
