using Flunt.Notifications;
using Flunt.Validations;
using LubyHour.Domain.Interfaces;
using System;

namespace LubyHour.Domain.Commands.Input.Management
{
    public class UpdateManagementCommand : Notifiable, ICommand
    {
        public Guid Id { get; set; }
        public string Developer { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                  .Requires()
                  .HasMinLen(Developer, 3, "Developer", "Nome do desenvolvedor deve conter no mínimo 3 caracteres!")
                  .HasMaxLen(Developer, 100, "Developer", "Nome do desenvolvedor deve conter no máximo 100 caracteres!")
                  .IsNotNull(Id, "Id", "Id não pode ser nulo!")
                  .IsNotNull(StartTime, "StartTime", "Data de início não pode ser nula!")
                  .IsNotNull(EndTime, "EndTime", "Data de finalização não pode ser nula!")

            );
        }
    }
}
