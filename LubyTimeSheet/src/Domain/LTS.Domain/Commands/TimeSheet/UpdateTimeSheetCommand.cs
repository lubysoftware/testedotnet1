using System;
using Flunt.Notifications;
using Flunt.Validations;
using LTS.Domain.Commands.Contracts;

namespace LTS.Domain.Commands.TimeSheet
{
    public class UpdateTimeSheetCommand : Notifiable, ICommand
    {
        public Guid Id { get; set; }
        public DateTime DateBegin { get; set; }
        public DateTime DateEnd { get; set; }

        public void Validate()
        {
            AddNotifications(
             new Contract()
                 .Requires()
                 .IsNotNull(Id, "Id", "Apontamento não encontrado.")
                 .IsLowerThan(DateBegin, DateEnd, "DateBegin", "Data inicial não pode ser maior que data final.")
                 .IsNotNull(DateBegin, "DateBegin", "Data Inicial inválida.")
                 .IsNotNull(DateEnd, "ProjectId", " Data final inválida.")
         );
        }
    }
}

