using Flunt.Notifications;
using Flunt.Validations;
using LTS.Domain.Commands.Contracts;

namespace LTS.Domain.Commands.Developer
{
    public class CreateDeveloperCommand : Notifiable, ICommand
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string LinkedinURL { get; set; }

        public void Validate()
        {
            AddNotifications(
              new Contract()
                  .Requires()
                  .IsNotNullOrEmpty(Name, "Name", "Por favor informe o nome do desenvolvedor.")
                  .IsNotNull(Age, "Age", "Por favor informe a idade do desenvolvedor.")
          );
        }
    }
}
