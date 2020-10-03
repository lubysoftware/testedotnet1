using System;
using System.Collections.Generic;
using TesteLuby.Domain.Contracts;

namespace TesteLuby.Domain.CommandsParameters
{
    public class CreateProjectCommand : ICommand
    {
        public string ProjectName { get; set; }
    }
}
