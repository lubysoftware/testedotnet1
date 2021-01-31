using ApiLuby.Models.Developers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiLuby.Configurations
{
    public interface IAuthenticationService
    {
        string GetToken(DeveloperViewModelOutput developerViewModelOutput);
    }
}
