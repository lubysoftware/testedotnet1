using System;

namespace LubyClocker.CrossCuting.Shared.Exceptions
{
    public class InvalidRequestException : Exception
    {
        public InvalidRequestException(string? message) : base(message)
        {
        }
    }
}