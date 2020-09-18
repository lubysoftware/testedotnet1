using System;
using LubyClocker.CrossCuting.Shared.Common;
using MediatR;

namespace LubyClocker.Application.BoundedContexts.Projects.Commands.Delete
{
    public class DeleteProjectCommand : BasicCommand<bool>
    {
    }
}