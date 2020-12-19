using System;
using System.Collections.Generic;
using System.Text;
using FabricaDeProjetos.Domain.Entities;

namespace Core.Contracts
{
    public interface ITokenServiceCore
    {
        string GenerateToken(Developer user);
    }
}
