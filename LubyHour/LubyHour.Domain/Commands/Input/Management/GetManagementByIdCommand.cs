
using Flunt.Notifications;
using LubyHour.Domain.Interfaces;
using System;

namespace LubyHour.Domain.Commands.Input.Management
{
    public class GetManagementByIdCommand : Notifiable, ICommand
    {
        public Guid Id { get; set; }
        public void Validate()
        {
            throw new System.NotImplementedException();
        }
    }
}
