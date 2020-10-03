using System;

using TesteLuby.Domain.Contracts;

namespace TesteLuby.Domain.CommandsParameters
{
    public class CreateBusinessHourCommand : ICommand
    {
        public int DeveloperId { get; set; }
        public DateTime DateTimeStart { get; set; }
        public DateTime DateTimeEnd { get; set; }
    }
}