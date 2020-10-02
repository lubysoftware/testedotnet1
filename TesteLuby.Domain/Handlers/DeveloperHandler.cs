using TesteLuby.Domain.Attributes;
using TesteLuby.Domain.Commands;
using TesteLuby.Domain.Contracts;
using TesteLuby.Domain.Enums;
using TesteLuby.Domain.Models.Entities;
using TesteLuby.Domain.Models.Settings;
using System;
using System.Threading.Tasks;
using TesteLuby.Domain.CommandsParameters;

namespace TesteLuby.Domain.Handlers
{
    public class DeveloperHandler : EntityHandler<Developer>, IHandler
    {
        private readonly AuthenticatedUser _authUser;

        public DeveloperHandler(IContext context, AuthenticatedUser authUser) : base(context)
        {
            _authUser = authUser;
        }

    }
}
