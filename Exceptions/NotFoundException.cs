using System;
using System.Runtime.Serialization;

namespace LancamentoHorasAPI.Services
{
    [Serializable]
    public class NotFoundException : ApplicationException
    {
        public NotFoundException(string msg) : base(msg)
        {
        }
    }
}