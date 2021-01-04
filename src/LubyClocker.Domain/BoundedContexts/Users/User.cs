using System;
using Microsoft.AspNetCore.Identity;

namespace LubyClocker.Domain.BoundedContexts.Users
{
    public class User : IdentityUser<Guid>
    {
    }
}