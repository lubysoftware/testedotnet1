using System;
using Flunt.Notifications;
using Flunt.Validations;
using LTS.Domain.Commands.Contracts;

namespace LTS.Domain.Commands.Project
{
    public class RemoveDeveloperFromProjectCommand : Notifiable, ICommand
    {
        public Guid DeveloperId { get; set; }
        public Guid ProjectId { get; set; }
        public void Validate()
        {
            AddNotifications(
             new Contract()
                 .Requires()
                 .IsNotNull(DeveloperId, "Id", "Desenvolvedor não encontrado")
                 .IsNotNull(ProjectId, "Id", "Projecto não encontrado")
         );
        }
    }
}
