using Flunt.Notifications;
using Flunt.Validations;
using LTS.Domain.Commands.Contracts;

namespace LTS.Domain.Commands.Project
{
    public class CreateProjectCommand : Notifiable, ICommand
    {
        public string Name { get; set; }
        public void Validate()
        {
            AddNotifications(
              new Contract()
                  .Requires()
                  .IsNotNullOrEmpty(Name, "Name", "Por favor informe o nome do projeto.")
          );
        }
    }
}
