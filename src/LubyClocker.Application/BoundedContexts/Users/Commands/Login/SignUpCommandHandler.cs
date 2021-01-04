using System.Threading;
using System.Threading.Tasks;
using LubyClocker.Application.BoundedContexts.Users.Commands.SignUp;
using LubyClocker.Application.BoundedContexts.Users.Services;
using LubyClocker.Application.BoundedContexts.Users.ViewModels;
using LubyClocker.CrossCuting.Shared;
using LubyClocker.CrossCuting.Shared.Exceptions;
using LubyClocker.Domain.BoundedContexts.Users;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace LubyClocker.Application.BoundedContexts.Users.Commands.Login
{
    public class LogInCommandHandler : IRequestHandler<LogInCommand, AuthenticationResult>
    {
        private readonly IAuthService _authService;
        private readonly SignInManager<User> _signInManager;

        public LogInCommandHandler(SignInManager<User> signInManager, IAuthService authService)
        {
            _signInManager = signInManager;
            _authService = authService;
        }

        public async Task<AuthenticationResult> Handle(LogInCommand request, CancellationToken cancellationToken)
        {
            var result = await _signInManager.PasswordSignInAsync(request.Email, request.Password, false, true);

            if (!result.Succeeded)
            {
                throw new InvalidRequestException(MainResource.LoginError);
            }

            return await _authService.GenerateJwtToken(request.Email);
        }
    }
}