using System;
using LubyClocker.CrossCuting.Shared.Common;
using MediatR;

namespace LubyClocker.Application.BoundedContexts.Developers.Commands.Delete
{
    public class DeleteDeveloperCommand : BasicCommand<bool>
    {
    }
}