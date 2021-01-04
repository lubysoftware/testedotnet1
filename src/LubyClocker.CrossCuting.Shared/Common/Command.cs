using System;
using MediatR;

namespace LubyClocker.CrossCuting.Shared.Common
{
    public class Command<T> : IRequest<T>
    {
    }
}