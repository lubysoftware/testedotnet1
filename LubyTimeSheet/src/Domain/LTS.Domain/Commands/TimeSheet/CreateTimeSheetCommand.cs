using Flunt.Notifications;
using Flunt.Validations;
using LTS.Domain.Commands.Contracts;
using System;

namespace LTS.Domain.Commands.TimeSheet
{
    public class CreateTimeSheetCommand : Notifiable, ICommand
    {
        public Guid DeveloperId { get; set; }
        public Guid ProjectId { get; set; }
        public DateTime DateBegin { get; set; }
        public DateTime DateEnd { get; set; }

        public void Validate()
        {
            AddNotifications(
             new Contract()
                 .Requires()
                 .IsNotNull(DeveloperId, "DeveloperId", "Desenvolvedor não encontrado.")
                 .IsNotNull(ProjectId, "ProjectId", "Projeto não encontrado.")
                 .IsLowerThan(DateBegin, DateEnd, "DateBegin", "Data inicial não pode ser maior que data final.")
                 .IsNotNull(DateBegin, "DateBegin", "Data Inicial inválida.")
                 .IsNotNull(DateEnd, "ProjectId", " Data final inválida.")

         );
        }
    }
}
