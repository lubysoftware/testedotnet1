using System.ComponentModel.DataAnnotations;
using LubyClocker.Application.BoundedContexts.Users.ViewModels;
using LubyClocker.CrossCuting.Shared.Common;

namespace LubyClocker.Application.BoundedContexts.Users.Commands.Login
{
    public class LogInCommand : Command<AuthenticationResult>
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}